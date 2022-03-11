using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AssetsByteUpsertHelper
{
    class Program
    {
        const string FILE = "assets.bytes";

        static void Log(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Log($@"usage :{Environment.NewLine}AssetsByteUpsertHelper.exe `Your Folder Path` 'Filter Regex(default all files)'");
                Log("");
                Log($@"example :{Environment.NewLine}AssetsByteUpsertHelper.exe `c:\folder1\folder2\` 'ui_jacket_*'");
                return;
            }

            var filterRegexStr = args.ElementAtOrDefault(1) ?? ".*";
            var filterRegex = new Regex(filterRegexStr);

            var assetsByteFileDirPath = args[0];
            var assetsByteFilePath = Path.Combine(assetsByteFileDirPath, FILE);
            var isUpdateAction = File.Exists(assetsByteFilePath);
            if (isUpdateAction)
            {
                Log("Program will update current exist `assets.bytes` file");
                var backupIdx = 0;
                Log("Backup file....");
                while (true)
                {
                    var backupFilePath = assetsByteFilePath + ".backup" + (backupIdx == 0 ? "" : backupIdx);
                    if (!File.Exists(backupFilePath))
                    {
                        File.Copy(assetsByteFilePath, backupFilePath, true);
                        Log("Backup file saved : " + backupFilePath);
                        break;
                    }
                    backupIdx++;
                }
            }
            else
            {
                File.WriteAllBytes(assetsByteFilePath, new byte[0]);
                Log("Program generate new `assets.bytes` file");
            }

            Log($"");
            Log($"filterRegexStr = {filterRegexStr}");
            Log($"assetsByteFileDirPath = {assetsByteFileDirPath}");
            Log($"assetsByteFilePath = {assetsByteFilePath}");

            var tempDstFilePath = Path.GetTempFileName();
            var tempSrcFilePath = Path.GetTempFileName();
            Log($"tempSrcFilePath : {tempSrcFilePath} {Environment.NewLine}tempDstFilePath : {tempDstFilePath}");

            File.Copy(assetsByteFilePath, tempSrcFilePath, true);

            using var srcFileStream = File.OpenRead(tempSrcFilePath);
            using var reader = new BinaryReader(srcFileStream);

            using var dstFileStream = File.OpenWrite(tempDstFilePath);
            using var writer = new BinaryWriter(dstFileStream);

            var bundlesCount = isUpdateAction && (reader.BaseStream.Length - reader.BaseStream.Position >= sizeof(int)) ? reader.ReadInt32() : 0;
            var bundleInfoList = Enumerable.Range(0, bundlesCount).Select(_ =>
            {
                var id = reader.ReadInt32();
                var name = reader.ReadString();
                var numDependencies = reader.ReadInt32();
                var dependencies = new int[numDependencies];
                for (int i = 0; i < numDependencies; i++)
                {
                    dependencies[i] = reader.ReadInt32();
                }
                return new { id, name, numDependencies, dependencies };
            }).ToList();

            var needInsertList = Directory.GetFiles(assetsByteFileDirPath)
                .Select(x=>Path.GetFileName(x))
                .Where(x=>filterRegex.IsMatch(x))
                .Except(bundleInfoList.Select(x=>x.name))
                .ToList();

            Log($"");
            if (needInsertList.Count > 0)
            {
                Log($"there are {needInsertList.Count} entries to append/update.");
                Log($"----Append Name List----");
                Log(string.Join(Environment.NewLine, needInsertList));
                Log($"------------------------");
            }
            else
            {
                Log($"no new entries to append, skipped.");
                return;
            }

            bundlesCount += needInsertList.Count;
            Log("current bundle total count : " + bundlesCount);
            writer.Write(bundlesCount);

            Log("Write same content...");
            var idx = 0;
            bundleInfoList.ForEach(x =>
            {
                writer.Write(x.id);
                writer.Write(x.name);
                writer.Write(x.numDependencies);
                for (int i = 0; i < x.numDependencies; i++)
                {
                    writer.Write(x.dependencies[i]);
                }
                idx++;
            });
            Log("Write append content...");
            needInsertList.ForEach(name =>
            {
                writer.Write(idx++);
                writer.Write(name);
                writer.Write(0);
            });
            Log("Writing all done!");

            writer.Flush();
            writer.Close();
            Log($"copy {tempDstFilePath} -> {assetsByteFilePath}");
            File.Copy(tempDstFilePath, assetsByteFilePath, true);

            Log($"Bye.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AssetsByteUpsertHelper
{
    class Program
    {
        static void Log(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        static void Main(string[] args)
        {
            if(args.Length <= 1)
            {
                Log($@"usage example:{Environment.NewLine}AssetsByteUpsertHelper.exe e:\...\assets.bytes ui_jacket_0999 ui_jacket_0999_s ...");
                return;
            }

            var upsertList = args.Skip(1).ToList();
            var assetsByteFilePath = args[0];
            var backupIdx = 0;
            Log("Backup file....");
            while (true)
            {
                var backupFilePath = assetsByteFilePath +  ".backup" + (backupIdx == 0 ? "" : backupIdx);
                if (!File.Exists(backupFilePath))
                {
                    File.Copy(assetsByteFilePath, backupFilePath, true);
                    Log("Backup file save : " + backupFilePath);
                    break;
                }
                backupIdx++;
            }

            var tempDstFilePath = Path.GetTempFileName();
            var tempSrcFilePath = Path.GetTempFileName();
            Log($"tempSrcFilePath : {tempSrcFilePath} {Environment.NewLine}tempDstFilePath : {tempDstFilePath}");
            File.Copy(assetsByteFilePath, tempSrcFilePath, true);

            using var srcFileStream = File.OpenRead(tempSrcFilePath);
            using var reader = new BinaryReader(srcFileStream);

            using var dstFileStream = File.OpenWrite(tempDstFilePath);
            using var writer = new BinaryWriter(dstFileStream);

            var bundlesCount = reader.ReadInt32();
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

            var needInsertList = upsertList.Except(bundleInfoList.Select(x => x.name).Intersect(upsertList)).ToList();
            if (needInsertList.Count > 0)
            {
                Log($"there are {needInsertList.Count} entries to append.");
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
            File.Copy(tempDstFilePath, assetsByteFilePath,true);

            Log($"Bye.");
        }
    }
}

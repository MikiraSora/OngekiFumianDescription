## 谱面封面
----
谱面封面的文件名格式固定`ui_jacket_xxxx`和`ui_jacket_xxxx_s`,两个文件虽然没有文件后缀名，但实际是unity的assets bundle文件.

* `ui_jacket_xxxx`<br>
谱面大图，一般用在游戏结算左下角处,图片512x512大小

* `ui_jacket_xxxx_s`<br>
谱面小图，一般用在游戏选歌界面处,图片220x220大小

### 如何生成谱面封面
首先谱面封面文件本质还是asset bundle文件，因此就要找工具去将图片文件转换成asset bundle，可惜目前还没找到合适的工具或者库去转换符合要求的asset bundle文件。因此就得下载unity本体，版本**必须**是和官方封面文件钦定的assetbundle版本一样，在summer是5.6.4f1.

**初次使用**
1. 打开Unity5.6.4f1,随便新建项目,打开此项目
2. 在Assets/Editor文件夹(没有就依次新建),新建C#文件BuildAssetBundles.cs,文件内容如下:
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class BuildAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    public static void onBuildAssetBundles()
    {
        var dir = @"C:\FumenJackets"; //这里是谱面封面文件输出文件夹

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
    }
}
```

3. 保存文件和项目
<br>
**可重复执行**
<br>
4. 将谱面封面图片文件导入进unity的Assets/assetbundles/ui/ui_jacket文件夹(没有就依次创建).<br>
5. 将每个图片文件,点击并查看Inspector,在最底下钦定Assetbundle设置.<br
![](https://raw.githubusercontent.com/MikiraSora/OngekiFumianDiscription/master/example/readme_img/4.png)

6. 所有图片资源都设置好后，在工具栏点击`Assets/Build Assetbundles`
![](https://raw.githubusercontent.com/MikiraSora/OngekiFumianDiscription/master/example/readme_img/5.png)<br>
图片资源将会打包成各个Asset Bundle文件并输出到代码中你提供的路径<br>
7. 去到打包输出的文件夹，将ui_jacket_xxxx和ui_jacket_xxxx_s无后缀名文件放到package\mu3_Data\StreamingAssets\assets处<br>
8. 使用或编译本项目tools/AssetsByteUpsertHelper,应用使用.net5运行时,将谱面封面的文件名注册到游戏的资源列表上,用法:<br>
> AssetsByteUpsertHelper.exe asset.bytes文件路径 新增的封面文件图片名1 新增的封面文件图片名2 ...<b
                                                                            
![](https://raw.githubusercontent.com/MikiraSora/OngekiFumianDiscription/master/example/readme_img/7.png)<br>
9. all done, enjoy

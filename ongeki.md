## 简介
此文件将描述ogkr文件(即音击谱面)里面的命令以及提供相关解释<br/>
注意,描述内容打上`(?)`即表示此内容不确定也不清楚，不保证后面有所改变

## 格式描述
|yy|yy|yy|yy|
|--|--|--|--|
|xx|xx|xx|xx|

yy行为描述,xx行为具体示例命令内容
<br/>
<br/>
<br/>
## 正文

### VERSION
|版本号|major|miror|release|
|--|--|--|--|
|VERSION|1|3|1|


### Creator
|谱面作者|dst|
|--|--|
|Creator|緑化委員長|


### BPM_DEF
|BPM定义信息|first|common|minimum|maximum|
|--|--|--|--|--|
|BPM_DEF|180|180|180|180|


### MET_DEF
|节拍信息|bunshi|bunbo|
|--|--|--|
|MET_DEF|4|4|


### TickResolution
|TGrid.ResT[\*1](#ongeki_md_1)|resT|
|--|--|
|TickResolution|1920|

<a name="ongeki_md_1">*</a>TickResolution,物件时间轴长度基准值，用来参与物件的下落速度和物件之间的垂直距离计算",resT 一般情况下默认1920



### XResolution
|XGrid.ResX[^2]|resX|
|--|--|
|XRESOLUTION|4096|

[^2]:XResolution,物件水平位置宽度基准值，用来参与物件水平位置计算的


### CLK_DEF
|初始节拍声音速度[^3]|clickDefault|
|--|--|
|CLK_DEF|1920|

[^3]:就是开头几个节拍音效(?)

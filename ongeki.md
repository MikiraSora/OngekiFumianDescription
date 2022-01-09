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


### BPM_DEF(Bpm Defintion)
|BPM定义信息|first|common|minimum|maximum|
|--|--|--|--|--|
|BPM_DEF|180|180|180|180|


### MET_DEF(Meter Defintion)
|节拍信息|bunshi|bunbo|
|--|--|--|
|MET_DEF|4|4|


### TickResolution
|TGrid.ResT[\*1](#ongeki_md_1)|resT|
|--|--|
|TickResolution|1920|

<a name="ongeki_md_1">*1:</a> TickResolution,物件时间轴长度基准值，用来参与物件的下落速度和物件之间的垂直距离计算",resT 一般情况下默认1920


### XResolution
|XGrid.ResX[\*2](#ongeki_md_2)|resX|
|--|--|
|XRESOLUTION|4096|

<a name="ongeki_md_2">*2:</a> XResolution,物件水平位置宽度基准值，用来参与物件水平位置计算的


### CLK_DEF(Click Defintion)
|初始节拍声音速度[\*3](#ongeki_md_3)|clickDefault|
|--|--|
|CLK_DEF|1920|

<a name="ongeki_md_3">*3:</a> 就是开头几个节拍音效(?)


### TUTORIAL (此命令没用到)
|是否为教程|isTutorial|
|--|--|
|TUTORIAL|0|


### BULLET_DAMAGE
|(?)伤害|damageBullet|
|--|--|
|BULLET_DAMAGE|1|


### HARDBULLET_DAMAGE
|(?)伤害|damageHardBullet|
|--|--|
|HARDBULLET_DAMAGE|2|


### DANGERBULLET_DAMAGE
|(?)伤害|damageDangerBullet|
|--|--|
|DANGERBULLET_DAMAGE|4|


### BEAM_DAMAGE
|激光伤害|damageBeam|
|--|--|
|BEAM_DAMAGE|2|


### PROGJUDGE_BPM
|(?)Hold相关|progJudgeBPM[\*4](#ongeki_md_4)|
|--|--|
|PROGJUDGE_BPM|240|

<a name="ongeki_md_4">*4:</a> 若<=1.00001f,则自动钦定为240

### BPL(Bullet Pallete List)
|子弹模板|strID|Shooter[\*5](#ongeki_md_5)|placeOffset (xUnit)|target[\*6](#ongeki_md_6)|speed|BulletType[\*7](#ongeki_md_7)|
|--|--|--|--|--|--|--|
|BPL|A0|UPS|0|FIX|1|NML|

<a name="ongeki_md_5">*5:</a>
Shooter枚举:
|枚举值|枚举全名|解释|
|--|--|--|
|UPS|TargetHead|从子弹终点位置发出,即在BLT等命令的XGrid位置|
|ENE|Enemy|从敌人位置|
|CEN|Center|基于谱面中心,即XGrid=(0,0)|

<a name="ongeki_md_6">*6:</a>
Target:
|枚举值|枚举全名|解释|
|--|--|--|
|PLR|Player|射向玩家位置|
|FIX|FixField|(?)射向对应位置，即在BLT等命令的XGrid位置|

<a name="ongeki_md_7">*7:</a>
BulletType:
|枚举值|枚举全名|解释|
|--|--|--|
|NML|Normal|使用BULLET_DAMAGE伤害|
|STR|Hard|使用HARDBULLET_DAMAGE伤害|
|DNG|Danger|使用DANGERBULLET_DAMAGE伤害|


### BTP(Bullet Choice)(此命令没用到)
|BulletChoice|(?)|
|--|--|
|BTP|(?)|


### BPM(Bpm Change)(此命令没用到)
|BPM变动|tUnit|tGrid|bpm|
|--|--|--|--|
|BPM|85|0|240|


### MET(Meter Change)
|节拍变动|tUnit|tGrid|bunshi|bunbo|
|--|--|--|--|--|
|MET|0|0|4|4|


### CLK(Click Sound)
|ClickSE,播放节奏辅助音效|tUnit|tGrid|
|--|--|--|
|CLK|0|0|


### SFL(Soflan , change playback speed)
|Soflan[\*8](#ongeki_md_8)|tUnit|tGrid|tGridLength[\*9](#ongeki_md_9)|soflan(?)|
|--|--|--|--|--|
|SFL|0|0|240|1|

<a name="ongeki_md_8">*8:</a> neta konmai的sof-lan<br/>
<a name="ongeki_md_9">*9:</a> 效果时效


### EST(EnemySet)
|播放敌人声音|tUnit|tGrid|tagTbl[\*10](#ongeki_md_10)|
|--|--|--|--|
|EST|0|0|WAVE1|

<a name="ongeki_md_10">*10:</a> 
WaveChangeConst.Tag:
|枚举值|枚举全名|解释|
|--|--|--|
|WAVE1||声音1|
|WAVE2||声音2|
|BOSS||Boss声音|






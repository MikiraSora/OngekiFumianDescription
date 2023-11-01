## 简介
此文件将描述ogkr文件(即音击谱面)里面的命令以及提供相关解释<br/>
注意,描述内容打上`(?)`即表示此内容不确定也不清楚，不保证后面有所改变<br/>
目前版本：bright memory 1.40

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
|子弹伤害|damageBullet|
|--|--|
|BULLET_DAMAGE|1|


### HARDBULLET_DAMAGE
|强化弹伤害|damageHardBullet|
|--|--|
|HARDBULLET_DAMAGE|2|


### DANGERBULLET_DAMAGE
|危险弹伤害|damageDangerBullet|
|--|--|
|DANGERBULLET_DAMAGE|4|


### BEAM_DAMAGE
|激光伤害|damageBeam|
|--|--|
|BEAM_DAMAGE|2|


### T_TOTAL
|T_TOTAL|所有物件判定总数量[\*20](#ongeki_md_20)|
|--|--|
|T_TOTAL|2500|

<a name="ongeki_md_20">*20:</a><br/> `T_TOTAL` = `T_TAP `+ `T_HOLD` + `T_SIDE` + `T_SHOLD` + `T_FLICK`<br/>
`PlatinumScore` = `T_TOTAL` * 2


### T_TAP
|T_TAP|Tap类判定数量[\*24](#ongeki_md_24)|
|--|--|
|T_TAP|595|

<a name="ongeki_md_21">*24:</a> `T_HOLD` = 所有Tap数量 + 所有Hold数量 - `T_SIDE`

### T_HOLD
|T_HOLD|Hold类判定数量(包括长条中间的判定)[\*21](#ongeki_md_21)|
|--|--|
|T_HOLD|1592|

<a name="ongeki_md_21">*21:</a> `T_HOLD` = 非墙壁Hold物件的数量

### T_SIDE
|T_SIDE|墙壁Tap类判定数量[\*22](#ongeki_md_22)|
|--|--|
|T_SIDE|132|

<a name="ongeki_md_22">*22:</a> `T_SIDE` = 墙壁Tap物件的数量 + 墙壁Hold物件的数量

### T_SHOLD
|T_SHOLD|墙壁Hold类判定数量(包括长条中间的判定)[\*23](#ongeki_md_23)|
|--|--|
|T_SHOLD|58|

<a name="ongeki_md_23">*23:</a> `T_SHOLD` = 墙壁Hold物件的数量以及它长度判定数量

### T_FLICK
|T_FLICK|Flick判定数量|
|--|--|
|T_FLICK|123|


### T_BELL
|T_FLICK|BELL判定数量|
|--|--|
|T_FLICK|159|


### PROGJUDGE_BPM
|(?)Hold相关|progJudgeBPM[\*4](#ongeki_md_4)|
|--|--|
|PROGJUDGE_BPM|240|

<a name="ongeki_md_4">*4:</a> 若<=1.00001f,则自动钦定为240

### BPL(Bullet Pallete List)
|子弹模板|strID|Shooter[\*5](#ongeki_md_5)|placeOffset (xUnit)|target[\*6](#ongeki_md_6)[\*32](#ongeki_md_32)|speed|BulletSize[\*7](#ongeki_md_7)|BulletType[\*17](#ongeki_md_17)| 
|--|--|--|--|--|--|--|--|
|BPL|A0|UPS|0|FIX|1|N|CIR|

<a name="ongeki_md_5">*5:</a>
Shooter枚举:
|枚举值|枚举全名|解释|
|--|--|--|
|UPS|TargetHead|从子弹终点位置发出,即在BLT等命令的XGrid位置|
|ENE|Enemy|从敌人位置，可以配合ENS(EnemyLaneStart)轨道配合使用|
|CEN|Center|基于谱面中心,即XGrid=(0,0)|

<a name="ongeki_md_6">*6:</a>
Target:
|枚举值|枚举全名|解释|
|--|--|--|
|PLR|Player|射向玩家位置|
|FIX|FixField|射向对应位置，即BLT等物件钦定的XGrid位置|

<a name="ongeki_md_7">*7:</a>
BulletSize:
|枚举值|枚举全名|解释|
|--|--|--|
|N|Normal|普通大小(**默认**)|
|L|Lerge|加大版(是普通版的1.4x)|

<a name="ongeki_md_17">*17:</a>
BulletType:
|枚举值|枚举全名|解释|
|--|--|--|
|CIR|Circle|圆形子弹|
|NDL|Needle|针状子弹|
|SQR|Square|圆柱形(方状)子弹|

### BTP(Bullet Choice)(此命令没用到)
|BulletChoice|(?)|
|--|--|
|BTP|(?)|


### BPM(Bpm Change)
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


### SFL(Soflan , change playback speed)[\*32](#ongeki_md_32)
|Soflan[\*8](#ongeki_md_8)|tUnit|tGrid|tGridLength[\*9](#ongeki_md_9)|当前速度倍率[\*33](#ongeki_md_33)|
|--|--|--|--|--|
|SFL|0|0|240|1|

<a name="ongeki_md_8">*8:</a> neta konmai的sof-lan<br/>
<a name="ongeki_md_9">*9:</a> 效果时效，超出这个时效时当前速度倍率会默认变回成1

<a name="ongeki_md_32">*32:</a> 对于`BLT`和`BEL`来说，它们一般也是受到变速影响。但如果它们引用的`BPL`对象的`Target`字段值为`PLR`(Player)时。则不受变速命令影响(即当作它们soflan一直为1)

<a name="ongeki_md_33">*33:</a> 如果想要谱面开倒车，那么仅需要给它设置负数


### EST(EnemySet)
|~~播放敌人声音~~|tUnit|tGrid|tagTbl[\*10](#ongeki_md_10)|
|--|--|--|--|
|EST|0|0|WAVE1|

<a name="ongeki_md_10">*10:</a> 
WaveChangeConst.Tag:
|枚举值|解释|
|--|--|
|WAVE1|声音1|
|WAVE2|声音2|
|BOSS|Boss声音，在合适的地方设置这个值的EST命令可以进入小妹妹BOSS对战阶段。如果不放置，那么游戏会默认在谱面中间时间段放置|


### WLS(WallLStart)
|左墙起始物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|WLS|173|1|960|-24|


### WLN(WallLNext)
|左墙(可重复)中间物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|WLN|173|2|960|0|


### WLE(WallLEnd)
|左墙中止物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|WLE|173|3|960|0|


### WRS(WallRStart)
|右墙起始物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|WRS|175|1|960|-24|


### WRN(WallRNext)
|右墙(可重复)中间物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|WRN|175|2|960|0|


### WRE(WallREnd)
|右墙中止物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|WRE|175|3|960|0|


### LLS(LaneLeftStart)
|红线起始物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|LLS|175|3|960|0|


### LLN(LaneLeftNext)
|红线(可重复)中间物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|LLN|175|3|960|0|


### LLE(LaneLeftEnd)
|红线中止物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|LLE|175|3|960|0|


### LCS(LaneCenterStart)
|绿线起始物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|LCS|175|3|960|0|


### LCN(LaneCenterNext)
|绿线(可重复)中间物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|LCN|175|3|960|0|


### LCE(LaneCenterEnd)
|绿线中止物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|LCE|175|3|960|0|

### LRS(LaneRightStart)
|蓝线起始物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|LRS|175|3|960|0|


### LRN(LaneRightNext)
|蓝线(可重复)中间物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|LRN|175|3|960|0|


### LRE(LaneRightEnd)
|蓝线中止物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|LRE|175|3|960|0|


### CLS(ColorfulLaneStart)
|其他颜色中止物件|GroupId|tUnit|tGrid|xUnit|colorfulLaneColorID[\*15](#ongeki_md_15)|colorfulLaneBrightnessID[\*16](#ongeki_md_16)|
|--|--|--|--|--|--|--|
|CLS|175|3|960|0|11|2|


### CLN(ColorfulLaneNext)
|其他颜色(可重复)中间物件|GroupId|tUnit|tGrid|xUnit|colorfulLaneColorID[\*15](#ongeki_md_15)|colorfulLaneBrightnessID[\*16](#ongeki_md_16)|
|--|--|--|--|--|--|--|
|CLN|175|3|960|0|11|2|

### CLN(ColorfulLaneEnd)
|其他颜色中止物件|GroupId|tUnit|tGrid|xUnit|colorfulLaneColorID[\*15](#ongeki_md_15)|colorfulLaneBrightnessID[\*16](#ongeki_md_16)|
|--|--|--|--|--|--|--|
|CLE|175|3|960|0|11|2|

<a name="ongeki_md_15">*15:</a> 虽然命令是"Colorful"但实际已经钦定好一系列自定义颜色了:
|值|颜色名字|颜色预览|
|--|--|--|
|0|ColorfulLaneAkari|![](http://via.placeholder.com/150x30/ff999e/white?text=+)|
|1|ColorfulLaneYuzu|![](http://via.placeholder.com/150x30/ffea73/white?text=+)|
|2|ColorfulLaneRio|![](http://via.placeholder.com/150x30/8d5ce0/white?text=+)|
|3|ColorfulLaneRiku|![](http://via.placeholder.com/150x30/ff71d9/white?text=+)|
|4|ColorfulLaneTsubaki|![](http://via.placeholder.com/150x30/50bfa3/white?text=+)|
|5|ColorfulLaneAyaka|![](http://via.placeholder.com/150x30/d169ed/white?text=+)|
|6|ColorfulLaneKaede|![](http://via.placeholder.com/150x30/484878/white?text=+)|
|7|ColorfulLaneSaki|![](http://via.placeholder.com/150x30/ced1d9/white?text=+)|
|8|ColorfulLaneKoboshi|![](http://via.placeholder.com/150x30/94f453/white?text=+)|
|9|ColorfulLaneArisu|![](http://via.placeholder.com/150x30/baf4fe/white?text=+)|
|10|ColorfulLaneMia|![](http://via.placeholder.com/150x30/febad4/white?text=+)|
|11|ColorfulLaneChinatsu|![](http://via.placeholder.com/150x30/ffd427/white?text=+)|
|12|ColorfulLaneTsumugi|![](http://via.placeholder.com/150x30/4f9bab/white?text=+)|
|13|ColorfulLaneSetsuna|![](http://via.placeholder.com/150x30/604aa3/white?text=+)|
|14|ColorfulLaneBrown|![](http://via.placeholder.com/150x30/964B00/white?text=+)|
|15|ColorfulLaneHaruna|![](http://via.placeholder.com/150x30/fef2f4/white?text=+)|
|16|ColorfulLaneBlack|![](http://via.placeholder.com/150x30/000000/white?text=+)|
|17|ColorfulLaneAkane|![](http://via.placeholder.com/150x30/cc0000/white?text=+)|
|18|ColorfulLaneG|![](http://via.placeholder.com/150x30/00ff00/white?text=+)|
|19|ColorfulLaneAoi|![](http://via.placeholder.com/150x30/4791ff/white?text=+)|

<a name="ongeki_md_16">*16:</a> 亮度值，具体有多亮就是相对于按照用户选项里那个轨道亮度 + 3 , 比如 colorfulLaneBrightnessID = 2 , 则实际就是`2 + 3 = 5`


### ENS(EnemyLaneStart)
|对面人物和杂鱼的移动轨迹起始物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|ENS|175|3|960|0|
玩玩ぱくぱく☆がーる紫谱，看看对面江江抽风

### ENN(EnemyLaneNext)
|对面人物和杂鱼的移动轨迹(可重复)中间物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|ENN|175|3|960|0|


### ENE(EnemyLaneEnd)
|对面人物和杂鱼的移动轨迹中止物件|GroupId|tUnit|tGrid|xUnit|
|--|--|--|--|--|
|ENE|175|3|960|0|


### LDP(LaneDisp)
|(?)|GroupId|Fore.tUnit|Fore.tGrid|Fore.xUnit|Fore.xGrid|Rear.tUnit|Rear.tGrid|Rear.xUnit|Rear.xGrid|
|--|--|--|--|--|--|--|--|--|--|
|LDP|173|92|1440|24|0|93|0|24|0|


### LBK(LaneBlock)
| 墙壁锁边 |GroupId[\*30](#ongeki_md_30)|Fore.tUnit|Fore.tGrid|Fore.xUnit|Fore.xGrid|Rear.tUnit|Rear.tGrid|Rear.xUnit|Rear.xGrid|
|--|--|--|--|--|--|--|--|--|--|
|LBK|173|92|1440|24|0|93|0|24|0|

<a name="ongeki_md_30">*30:</a> 每个LBK只能锁一个边，至于锁哪边就看GroupId引用的墙的类型。比如你想锁左边的墙不想让人物超出这个边界，那么只需要LBK的GroupId设置成对应左墙的RecordId即可，但注意LBK有效持续时间应该在墙轨道的显示时间范围内。

### BLT(Bullet)[\*32](#ongeki_md_32)
|Bullet|strId|tUnit|tGrid|xUnit|BulletType[\*18](#ongeki_md_18)|
|--|--|--|--|--|--|
|BLT|A0|30|960|-24|NML|

<a name="ongeki_md_18">*18:</a>
BulletType:
|枚举值|枚举全名|解释|
|--|--|--|
|NML|Normal|使用BULLET_DAMAGE伤害|
|STR|Hard|使用HARDBULLET_DAMAGE伤害|
|DNG|Danger|使用DANGERBULLET_DAMAGE伤害|


### BMS(BeamStart)
|激光起始物件|recordId|tUnit|tGrid|xUnit|widthID[\*11](#ongeki_md_11)|
|--|--|--|--|--|--|
|BMS|0|117|960|-40|4|


### BMN(BeamNext)
|激光(可重复)中间物件|recordId|tUnit|tGrid|xUnit|widthID[\*11](#ongeki_md_11)|
|--|--|--|--|--|--|
|BMN|0|117|1500|-40|4|


### BME(BeamEnd)
|激光终中止物件|recordId|tUnit|tGrid|xUnit|widthID[\*11](#ongeki_md_11)|
|--|--|--|--|--|--|
|BME|0|117|1500|-40|4|


### OBS(ObliqueBeamStart)
|倾斜激光起始物件|recordId|tUnit|tGrid|xUnit|widthID[\*11](#ongeki_md_11)|shootPosXUnitOffset[\*31](#ongeki_md_31)|
|--|--|--|--|--|--|--|
|OBS|0|117|960|-40|4|5|

<a name="ongeki_md_31">*31:</a>以OBS的水平位置为基准，偏移XUnit个单位作为固定位置，向着当前时间内激光轨道的位置发射激光。因此只有OBS的shootPosXUnitOffset是有用的,OBN和OBE的shootPosXUnitOffset不会起作用

### OBN(ObliqueBeamNext)
|倾斜激光(可重复)中间物件|recordId|tUnit|tGrid|xUnit|widthID[\*11](#ongeki_md_11)|shootPosXUnitOffset[\*31](#ongeki_md_31)|
|--|--|--|--|--|--|--|
|BMN|0|117|1500|-40|4|5|


### OBE(ObliqueBeamEnd)
|倾斜激光终中止物件|recordId|tUnit|tGrid|xUnit|widthID[\*11](#ongeki_md_11)|shootPosXUnitOffset[\*31](#ongeki_md_31)|
|--|--|--|--|--|--|--|
|BME|0|117|1500|-40|4|5|


<a name="ongeki_md_11">*11:</a> 
widthID:
|枚举值|对应的widthJudge|对应的widthDraw|
|--|--|--|
|1(default)|4|2|
|2|6|3|
|3|8|4|
|4|16|12|
|5|24|20|


### BEL(Bell)[\*32](#ongeki_md_32)
|Bell物件|tUnit|tGrid|xUnit|bulletPallete[\*19](#ongeki_md_19)|
|--|--|--|--|--|
|BEL|3|1440|4|-- 或 某个BPL的strID|

<a name="ongeki_md_19">*19:</a> 如果钦定了bulletPallete,那么Bell就会像子弹一样可能实时位移和应用速度(比如 Op.1)。

### FLK(Flick) or CFK(CriticalFlick)
|(Critical)Flick|tUnit|tGrid|xUnit|Direction|
|--|--|--|--|--|
|`FLK` or `CFK`|3|1440|4|`L` or `R`|


### TAP or CTP/XTP[\*12](#ongeki_md_12)(CriticalTap)
|(Critical)Tap|laneGroupId[\*13](#ongeki_md_13)[\*14](#ongeki_md_14)|tUnit|tGrid|xUnit|xGrid|
|--|--|--|--|--|--
|`TAP` or (`CTP` = `XTP`)|72|11|1440|24|0|

<a name="ongeki_md_12">*12:</a> XTP全名ExTap，但等同于CTP(CriticalTap)


### HLD(Hold) or CHD/XHD[\*15](#ongeki_md_15)(CriticalHold)
|(Critical)Hold|laneGroupId[\*13](#ongeki_md_13)[\*14](#ongeki_md_14)|Fore.tUnit|Fore.tGrid|Fore.xUnit|Fore.xGrid|Rear.tUnit|Rear.tGrid|Rear.xUnit|Rear.xGrid|
|--|--|--|--|--|--|--|--|--|--|
|`HLD` or (`CHD` = `XHD`)|151|1|1200|-12|0|1|1680|-12|0|

<a name="ongeki_md_12">*15:</a> XHD全名ExHold，但等同于CHD(CriticalHold)<br/>
<a name="ongeki_md_13">*13:</a> Tap/Hold需要引用Lane的GroupId,但引用这货仅仅是为了钦定物件的颜色和类型<br/>
<a name="ongeki_md_14">*14:</a> 墙壁也是Lane一种，因此墙壁Tap/Hold也是按照此命令引用墙壁的GroupId即可<br/>


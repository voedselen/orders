�1
�C:\Users\Klave\OneDrive - Office 365 Fontys\Documents\GitHub\orders\Backend\VoedselBackend\VoedselASP\Controllers\OrderController.cs
	namespace 	

VoedselASP
 
. 
Controllers  
{		 
[

 
Route

 

(


 
$str

 
)

 
]

 
[ 

] 
public 

class 
OrderController  
:! "
ControllerBase# 1
{
private 
readonly 
IOrderBusinessLogic ,
_orderLogic- 8
;8 9
public 
OrderController 
( 
IOrderBusinessLogic 2
iAccessOrder3 ?
)? @
{ 	
_orderLogic 
= 
iAccessOrder &
;& '
} 	
[ 	
HttpGet	 
( 
template 
: 
$str #
)# $
]$ %
public 

Get  
(  !
)! "
{ 	
bool 
result 
= 
true 
; 
try 
{ 
List 
< 
Order 
> 
orders "
=# $
_orderLogic$ /
./ 0
ReadOrdersDB0 <
(< =
)= >
;> ?
var 
response 
= 
new "
{# $
result% +
=, -
result. 4
,4 5
status6 <
== >
$num? B
,B C
messageD K
=L M
$strN W
,W X
ordersY _
=_ `
orders` f
.f g
ToArrayg n
(n o
)o p
}q r
;r s
return 
Ok 
( 
response "
)" #
;# $
} 
catch 
( 
	Exception 
ex 
)  
{   
result!! 
=!! 
false!! 
;!! 
var"" 
response"" 
="" 
new"" "
{""# $
result""% +
="", -
result"". 4
,""4 5
status""6 <
=""= >
$num""? B
,""B C
message""D K
=""L M
ex""N P
.""P Q
Message""Q X
}""Y Z
;""Z [
return## 

BadRequest## !
(##! "
response##" *
)##* +
;##+ ,
}$$ 
}%% 	
[(( 	
HttpPost((	 
((( 
template(( 
:(( 
$str(( !
)((! "
]((" #
public)) 

Post)) !
())! "
[))" #
FromBody))# +
]))+ ,
Order))- 2
order))3 8
)))8 9
{** 	
bool++ 
result++ 
=++ 
true++ 
;++ 
try-- 
{.. 
_orderLogic// 
.// 

AddOrderDB// &
(//& '
order//' ,
)//, -
;//- .
var00 
response00 
=00 
new00 "
{00# $
result00% +
=00, -
result00. 4
,004 5
status006 <
=00< =
$num00= @
,00@ A
message00B I
=00I J
$str00J S
}00T U
;00U V
return11 
Ok11 
(11 
response11 "
)11" #
;11# $
}22 
catch33 
(33 
	Exception33 
ex33 
)33 
{44 
result55 
=55 
false55 
;55 
var66 
response66 
=66 
new66 "
{66# $
result66% +
=66, -
result66. 4
,664 5
status666 <
=66= >
$num66? B
,66B C
message66D K
=66K L
ex66L N
.66N O
Message66O V
}66W X
;66X Y
return77 

BadRequest77 !
(77! "
response77" *
)77* +
;77+ ,
}88 
}99 	
[<< 	
HttpPut<<	 
(<< 
$str<< 
)<< 
]<< 
public== 
void== 
Put== 
(== 
int== 
id== 
,== 
[==  !
FromBody==! )
]==) *
string==+ 1
value==2 7
)==7 8
{>> 	
}?? 	
[BB 	

HttpDeleteBB	 
(BB 
templateBB 
:BB 
$strBB &
)BB& '
]BB' (
publicCC 

DeleteCC #
(CC# $
[CC$ %
	FromQueryCC% .
]CC. /
intCC0 3
idCC4 6
)CC6 7
{DD 	
boolEE 
resultEE 
=EE 
trueEE 
;EE 
tryGG 
{HH 
_orderLogicII 
.II 

(II) *
idII* ,
)II, -
;II- .
varJJ 
responseJJ 
=JJ 
newJJ "
{JJ# $
resultJJ% +
=JJ, -
resultJJ. 4
,JJ4 5
statusJJ6 <
=JJ= >
$numJJ? B
,JJB C
messageJJD K
=JJL M
$strJJN W
}JJX Y
;JJY Z
returnKK 
OkKK 
(KK 
responseKK "
)KK" #
;KK# $
}LL 
catchMM 
(MM 
	ExceptionMM 
exMM 
)MM  
{NN 
resultOO 
=OO 
falseOO 
;OO 
varPP 
responsePP 
=PP 
newPP "
{PP# $
resultPP% +
=PP, -
resultPP. 4
,PP4 5
statusPP6 <
=PP= >
$numPP? B
,PPB C
messagePPD K
=PPL M
exPPN P
.PPP Q
MessagePPQ X
}PPY Z
;PPZ [
returnQQ 

BadRequestQQ !
(QQ! "
responseQQ" *
)QQ* +
;QQ+ ,
}RR 
}SS 	
}TT 
}UU �
�C:\Users\Klave\OneDrive - Office 365 Fontys\Documents\GitHub\orders\Backend\VoedselBackend\VoedselASP\Controllers\WeatherForecastController.cs
	namespace 	

VoedselASP
 
. 
Controllers  
{ 
[ 

] 
[ 
Route 

(
 
$str 
) 
] 
public 

class %
WeatherForecastController *
:+ ,
ControllerBase- ;
{ 
private		 
static		 
readonly		 
string		  &
[		& '
]		' (
	Summaries		) 2
=		3 4
new		5 8
[		8 9
]		9 :
{

 	
$str 
, 
$str 
, 
$str '
,' (
$str) /
,/ 0
$str1 7
,7 8
$str9 ?
,? @
$strA H
,H I
$strJ O
,O P
$strQ ]
,] ^
$str_ j
} 
; 
private 
readonly 
ILogger  
<  !%
WeatherForecastController! :
>: ;
_logger< C
;C D
public %
WeatherForecastController (
(( )
ILogger) 0
<0 1%
WeatherForecastController1 J
>J K
loggerL R
)R S
{ 	
_logger 
= 
logger 
; 
} 	
[ 	
HttpGet	 
( 
Name 
= 
$str ,
), -
]- .
public 
IEnumerable 
< 
WeatherForecast *
>* +
Get, /
(/ 0
)0 1
{ 	
return 

Enumerable 
. 
Range #
(# $
$num$ %
,% &
$num' (
)( )
.) *
Select* 0
(0 1
index1 6
=>7 9
new: =
WeatherForecast> M
{ 
Date 
= 
DateTime 
.  
Now  #
.# $
AddDays$ +
(+ ,
index, 1
)1 2
,2 3
TemperatureC 
= 
Random %
.% &
Shared& ,
., -
Next- 1
(1 2
-2 3
$num3 5
,5 6
$num7 9
)9 :
,: ;
Summary 
= 
	Summaries #
[# $
Random$ *
.* +
Shared+ 1
.1 2
Next2 6
(6 7
	Summaries7 @
.@ A
LengthA G
)G H
]H I
} 
)
. 
ToArray
( 
) 
; 
} 	
}   
}!! �
pC:\Users\Klave\OneDrive - Office 365 Fontys\Documents\GitHub\orders\Backend\VoedselBackend\VoedselASP\Program.cs
var 
builder 
= 
WebApplication 
. 

(* +
args+ /
)/ 0
;0 1
builder

 
.

 
Services

 
.

 
AddControllers

 
(

  
)

  !
;

! "
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder
.
Services
.

(
)
;
builder 
. 
Services 
. 
AddSingleton 
< 
IOrderBusinessLogic 1
>1 2
(2 3
new3 6
AccessOrders7 C
(C D
newD G
DB_AccessOrderH V
(V W
)W X
)X Y
)Y Z
;Z [
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
app 
. 
UseCors 
( 
policy 
=> 
{ 
policy 

.
 
WithOrigins 
( 
$str .
). /
.
 
AllowAnyHeader 
( 
) 
.
 
AllowAnyMethod 
( 
) 
.
 
AllowCredentials 
( 
) 
; 
} 
) 
; 
if 
( 
app 
. 
Environment 
. 

(! "
)" #
)# $
{ 
app 
. 

UseSwagger 
( 
) 
; 
app 
. 
UseSwaggerUI 
( 
) 
; 
}   
app"" 
."" 
UseHttpsRedirection"" 
("" 
)"" 
;"" 
app$$ 
.$$ 
UseAuthorization$$ 
($$ 
)$$ 
;$$ 
app&& 
.&& 
MapControllers&& 
(&& 
)&& 
;&& 
app(( 
.(( 
Run(( 
((( 
)(( 	
;((	 
�
xC:\Users\Klave\OneDrive - Office 365 Fontys\Documents\GitHub\orders\Backend\VoedselBackend\VoedselASP\WeatherForecast.cs
	namespace 	

VoedselASP
 
{ 
public 

class 
WeatherForecast  
{ 
public 
DateTime 
Date 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
TemperatureC 
{  !
get" %
;% &
set' *
;* +
}, -
public		 
int		 
TemperatureF		 
=>		  "
$num		# %
+		& '
(		( )
int		) ,
)		, -
(		- .
TemperatureC		. :
/		; <
$num		= C
)		C D
;		D E
public 
string 
? 
Summary 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
}
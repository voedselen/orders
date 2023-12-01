ûd
tC:\Users\Klave\OneDrive - Office 365 Fontys\Documents\GitHub\orders\Backend\VoedselBackend\DBLayer\DB_AccessOrder.cs
	namespace 	
DBLayer
 
{ 
public 

class 
DB_AccessOrder 
:  !
IDB_AccessOrder" 1
{ 
private 
const 
string 
CONNECTION_STRING .
=/ 0
$str	1 ¸
;
¸ ¹
public 
bool 

AddOrderDB 
( 
Order $
order% *
)* +
{ 	
try 
{ 
SqlConnection 

connection (
=) *
new+ .
SqlConnection/ <
(< =
CONNECTION_STRING= N
)N O
;O P

connection 
. 
Open 
(  
)  !
;! "

SqlCommand 
insertCommand (
=) *
new+ .

SqlCommand/ 9
(9 :
$str: p
+q r
$str +
,+ ,

connection- 7
)7 8
;8 9
insertCommand 
. 

Parameters (
.( )
AddWithValue) 5
(5 6
$str6 D
,D E
orderF K
.K L

OrderTableL V
)V W
;W X
int 
orderID 
= 
Convert %
.% &
ToInt32& -
(- .
insertCommand. ;
.; <
ExecuteScalar< I
(I J
)J K
)K L
;L M
if 
( 
order 
. 

OrderItems $
.$ %
Count% *
!=+ -
$num. /
)/ 0
{ 
foreach 
( 
MenuItem %
menuItem& .
in/ 1
order2 7
.7 8

OrderItems8 B
)B C
{   

SqlCommand!! "
insertItemCommand!!# 4
=!!5 6
new!!7 :

SqlCommand!!; E
(!!E F
$str!!F |
+!!} ~
$str"" <
,""< =

connection""> H
)""H I
;""I J
insertItemCommand## )
.##) *

Parameters##* 4
.##4 5
AddWithValue##5 A
(##A B
$str##B M
,##M N
orderID##O V
)##V W
;##W X
insertItemCommand$$ )
.$$) *

Parameters$$* 4
.$$4 5
AddWithValue$$5 A
($$A B
$str$$B N
,$$N O
menuItem$$P X
.$$X Y
name$$Y ]
)$$] ^
;$$^ _
insertItemCommand%% )
.%%) *

Parameters%%* 4
.%%4 5
AddWithValue%%5 A
(%%A B
$str%%B J
,%%J K
menuItem%%L T
.%%T U
price%%U Z
)%%Z [
;%%[ \
insertItemCommand&& )
.&&) *
ExecuteNonQuery&&* 9
(&&9 :
)&&: ;
;&&; <
}'' 
}(( 

connection)) 
.)) 
Close))  
())  !
)))! "
;))" #
return** 
true** 
;** 
}++ 
catch,, 
(,, 
	Exception,, 
ex,, 
),,  
{-- 
Console.. 
... 
	WriteLine.. !
(..! "
ex.." $
...$ %
ToString..% -
(..- .
)... /
)../ 0
;..0 1
return// 
false// 
;// 
}00 
}11 	
public33 
bool33 
DeleteOrderDB33 !
(33! "
int33" %
id33& (
)33( )
{44 	
try55 
{66 
SqlConnection77 

connection77 (
=77) *
new77+ .
SqlConnection77/ <
(77< =
CONNECTION_STRING77= N
)77N O
;77O P

connection88 
.88 
Open88 
(88  
)88  !
;88! "
string99 
deleteItemCommand99 (
=99) *
(99+ ,
$str99, W
+99X Y
id99Z \
.99\ ]
ToString99] e
(99e f
)99f g
+99h i
$str99j m
)99m n
;99n o

SqlCommand:: 
sqlItemCommand:: )
=::* +
new::, /

SqlCommand::0 :
(::: ;
deleteItemCommand::; L
,::L M

connection::N X
)::X Y
;::Y Z
sqlItemCommand;; 
.;; 
ExecuteNonQuery;; .
(;;. /
);;/ 0
;;;0 1
string<< 
deleteCommand<< $
=<<% &
(<<' (
$str<<( H
+<<I J
id<<K M
.<<M N
ToString<<N V
(<<V W
)<<W X
+<<Y Z
$str<<[ ^
)<<^ _
;<<_ `

SqlCommand== 

sqlCommand== %
===& '
new==( +

SqlCommand==, 6
(==6 7
deleteCommand==7 D
,==D E

connection==F P
)==P Q
;==Q R
int>> 
rowsAffected>>  
=>>! "

sqlCommand>># -
.>>- .
ExecuteNonQuery>>. =
(>>= >
)>>> ?
;>>? @

connection?? 
.?? 
Close??  
(??  !
)??! "
;??" #
return@@ 
true@@ 
;@@ 
}AA 
catchBB 
(BB 
	ExceptionBB 
exBB 
)BB  
{CC 
ConsoleDD 
.DD 
	WriteLineDD !
(DD! "
exDD" $
.DD$ %
ToStringDD% -
(DD- .
)DD. /
)DD/ 0
;DD0 1
returnEE 
falseEE 
;EE 
}FF 
}GG 	
publicHH 
ListHH 
<HH 
OrderHH 
>HH 
?HH 
ReadOrdersDBHH (
(HH( )
)HH) *
{II 	
ListJJ 
<JJ 
OrderJJ 
>JJ 
ordersJJ 
=JJ  
newJJ! $
ListJJ% )
<JJ) *
OrderJJ* /
>JJ/ 0
(JJ0 1
)JJ1 2
;JJ2 3
tryKK 
{LL 
SqlConnectionMM 

connectionMM (
=MM) *
newMM+ .
SqlConnectionMM/ <
(MM< =
CONNECTION_STRINGMM= N
)MMN O
;MMO P

connectionNN 
.NN 
OpenNN 
(NN  
)NN  !
;NN! "

SqlCommandOO 
readOrderCommandOO +
=OO, -
newOO. 1

SqlCommandOO2 <
(OO< =
$strOO= S
,OOS T

connectionOOU _
)OO_ `
;OO` a
SqlDataReaderQQ 
readerCommandQQ +
=QQ, -
readOrderCommandQQ. >
.QQ> ?
ExecuteReaderQQ? L
(QQL M
)QQM N
;QQN O
whileRR 
(RR 
readerCommandRR $
.RR$ %
ReadRR% )
(RR) *
)RR* +
)RR+ ,
{SS 
intTT 
IDTT 
=TT 
(TT 
intTT !
)TT! "
readerCommandTT" /
[TT/ 0
$strTT0 4
]TT4 5
;TT5 6
intUU 
tableUU 
=UU 
(UU  !
intUU! $
)UU$ %
readerCommandUU% 2
[UU2 3
$strUU3 @
]UU@ A
;UUA B
OrderVV 
orderVV 
=VV  !
newVV" %
OrderVV& +
(VV+ ,
IDVV, .
,VV. /
newVV0 3
ListVV4 8
<VV8 9
MenuItemVV9 A
>VVA B
(VVB C
)VVC D
,VVD E
tableVVF K
)VVK L
;VVL M
ordersWW 
.WW 
AddWW 
(WW 
orderWW $
)WW$ %
;WW% &
}XX 
readerCommandYY 
.YY 
CloseYY #
(YY# $
)YY$ %
;YY% &
foreachZZ 
(ZZ 
OrderZZ 
orderZZ $
inZZ% '
ordersZZ( .
)ZZ. /
{[[ 

SqlCommand\\ 
readItemsCommand\\ /
=\\0 1
new\\2 5

SqlCommand\\6 @
(\\@ A
$str\\A n
+\\o p
order\\q v
.\\v w
ID\\w y
.\\y z
ToString	\\z ‚
(
\\‚ ƒ
)
\\ƒ „
+
\\… †
$str
\\‡ Š
,
\\Š ‹

connection
\\Œ –
)
\\– —
;
\\— ˜
SqlDataReader^^ !
readerItemsCommand^^" 4
=^^5 6
readItemsCommand^^7 G
.^^G H
ExecuteReader^^H U
(^^U V
)^^V W
;^^W X
while__ 
(__ 
readerItemsCommand__ -
.__- .
Read__. 2
(__2 3
)__3 4
)__4 5
{`` 
intaa 
priceaa !
=aa" #
(aa$ %
intaa% (
)aa( )
readerItemsCommandaa) ;
[aa; <
$straa< C
]aaC D
;aaD E
stringbb 
namebb #
=bb$ %
(bb& '
stringbb' -
)bb- .
readerItemsCommandbb. @
[bb@ A
$strbbA L
]bbL M
;bbM N
ordercc 
.cc 
AddMenuItemcc )
(cc) *
namecc* .
,cc. /
pricecc0 5
)cc5 6
;cc6 7
}dd 
readerItemsCommandee &
.ee& '
Closeee' ,
(ee, -
)ee- .
;ee. /
}ff 

connectiongg 
.gg 
Closegg  
(gg  !
)gg! "
;gg" #
}hh 
catchii 
(ii 
	Exceptionii 
exii 
)ii  
{jj 
Consolekk 
.kk 
	WriteLinekk !
(kk! "
exkk" $
.kk$ %
ToStringkk% -
(kk- .
)kk. /
)kk/ 0
;kk0 1
returnll 
nullll 
;ll 
}mm 
returnnn 
ordersnn 
;nn 
}oo 	
publicqq 
Listqq 
<qq 
MenuItemqq 
>qq 
ReadMenuItemsDbqq -
(qq- .
intqq. 1
orderIdqq2 9
)qq9 :
{rr 	
SqlConnectionss 

connectionss $
=ss% &
newss' *
SqlConnectionss+ 8
(ss8 9
CONNECTION_STRINGss9 J
)ssJ K
;ssK L
Listtt 
<tt 
MenuItemtt 
>tt 
	menuItemstt $
=tt% &
newtt' *
Listtt+ /
<tt/ 0
MenuItemtt0 8
>tt8 9
(tt9 :
)tt: ;
;tt; <

connectionvv 
.vv 
Openvv 
(vv 
)vv 
;vv 

SqlCommandww  
readOrderItemCommandww +
=ww, -
newww. 1

SqlCommandww2 <
(ww< =
$strww= q
,wwq r

connectionwws }
)ww} ~
;ww~  
readOrderItemCommandxx  
.xx  !

Parametersxx! +
.xx+ ,
AddWithValuexx, 8
(xx8 9
$strxx9 D
,xxD E
orderIdxxF M
)xxM N
;xxN O
SqlDataReaderzz 
itemReaderCommandzz +
=zz, - 
readOrderItemCommandzz. B
.zzB C
ExecuteReaderzzC P
(zzP Q
)zzQ R
;zzR S
while{{ 
({{ 
itemReaderCommand{{ $
.{{$ %
Read{{% )
({{) *
){{* +
){{+ ,
{|| 
int}} 
ID}} 
=}} 
(}} 
int}} 
)}} 
itemReaderCommand}} /
[}}/ 0
$str}}0 :
]}}: ;
;}}; <
string~~ 
menuItem~~ 
=~~  !
(~~" #
string~~# )
)~~) *
itemReaderCommand~~* ;
[~~; <
$str~~< G
]~~G H
;~~H I
int 
price 
= 
( 
int  
)  !
itemReaderCommand! 2
[2 3
$str3 :
]: ;
;; <
MenuItem
€€ 
	itemToAdd
€€ "
=
€€# $
new
€€% (
MenuItem
€€) 1
(
€€1 2
menuItem
€€2 :
,
€€: ;
price
€€< A
)
€€A B
;
€€B C
	menuItems
 
.
 
Add
 
(
 
	itemToAdd
 '
)
' (
;
( )
}
‚‚ 

connection
„„ 
.
„„ 
Close
„„ 
(
„„ 
)
„„ 
;
„„ 
return
…… 
	menuItems
…… 
;
…… 
}
†† 	
}
‡‡ 
}ˆˆ 
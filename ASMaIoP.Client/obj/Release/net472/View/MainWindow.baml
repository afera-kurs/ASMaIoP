   M S B A M L   `   `   `  ???? I  EASMaIoP.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ASMaIoP.ClientASMaIoP.Client  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem     ASMaIoP.Client.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Hi:http://schemas.microsoft.com/expression/2010/interactivity     Hei9http://schemas.microsoft.com/expression/2010/interactions     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  (localclr-namespace:ASMaIoP.Client  3system&clr-namespace:System;assembly=mscorlib  -     ? WindowState$  	Maximized=????	#01000000 ? Title$ ASMaIoP??$	??850??$
??1600??.??? 
??????? ? ColumnDefinitions ?? $	??200 ??? $??40 ??? $??1080* ??? $
??120* ? ? RowDefinitions ?? $
??100* ??? $
??156* ??? $
??100* ??? $
??256* ??? $
??256* ?.+?? $??1??$??0??$??4??$??4??.+??? $??170,30,30,30q? ?? CornerRadius$ 40,40,40,300??   
CoreBorder#???    J? Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 5Q?   	Direction$	 270Q?   Color$ Black??	   Opacity$		 0.5Q?
   
BlurRadius$
 7Q?._??  ?? $
??1.3* ??? ?? ?? ?? ?? ??  ?? ?? ?? ?? ?? ?? .+??? -    ??Name$ CCLeft??$??4??$??20q??? -   $ CCRight??$??6??$??1??$??6??? $??2??.+??? -    ??Name$ TopPanel??$y?	Collapsed=?  OtherBorder#???  $??80??$ 	0,0,80,80??$	??Top=?   $ 5Q?$	 270Q?$ Black??$		 0.5Q?$
 7Q?._??  ? ShowGridLines$ False?? ?? $??70 ??? $??* ??? $??* ??? $??* ??? $??* ??? $??* ??? $??* ??? $??* ??? $??* ??? $??70 ?.+??? -     RoundCorner#???  $??50??$??1??$??Center=?$??18(????#093b46???#cdd0c8$ ??Редактировать???? -   #???  $??50??$??2??$??Center=?$??22(????#093b46???#cdd0c8$??Bytton1???? #???  $??50??$??3??$??Center=?$??22(????#093b46???#cdd0c8$??Bytton1???? #???  $??50??$??4??$??Center=?$??22(????#093b46???#cdd0c8$??Bytton1???? #???  $??50??$??5??$??Center=?$??22(????#093b46???#cdd0c8$??Bytton1???? #???  $??50??$??6??$??Center=?$??22(????#093b46???#cdd0c8$??Bytton1???? #???  $??50??$??7??$??Center=?$??22(????#093b46???#cdd0c8$??Bytton1???? #???  $??50??$??8??$??Center=?$??22(????#093b46???#cdd0c8$??Bytton1??? $??3??  ? 	Resources   SlideOffSet  
SlideRight ?? TargetProperty W? From	 W? To g? Duration  	SlideLeft??%?   &	       &	      7  &	 l     7  X?156Q??? .??W? $8 2(UIElement.RenderTransform).(TranslateTransform.X)? 08   $ 0:0:0.3D??? .??W? $8 2(UIElement.RenderTransform).(TranslateTransform.X)?8    0$ 0:0:0.3D?.+???  ?? Orientation$ 
Horizontal=?$??-156, 0, 0, 0q?????  ?? 
TargetType" ?? ?? Triggers :?  :? RoutedEvent$ 
MouseEnter??[??? #??[ :? $ 
MouseLeave??[??? #??[ z?T? .+??? -   $ borderSwitch??$??0??$??2??$	??200??$
??Left=?#???  $ 	0,40,40,0?? J? RenderTransformOrigin$ 0.5,0.5&?z?V? .~??? ?? ?? T?    $ 5Q?$	 270Q?$ Black??$		 0.5Q?$
 7Q?._??  ?? $	??10* ??? $	??10* ? ?? $	??10* ??? $
??2.5* ?.+??? -    ??Name$ ButtonProfile??$??70??$	??150??  SwitchMenuButton#???  $
??Left=?$??5q?.???? -	    ??Name$ 	textBlock??$??0??$??18(?
???   ?$??Center=?$??Профиль???? $??0??$??1??$??2q???H?  H? Drawing I?  I? ClipGeometry4 ??        ?    `ö?`ö`ö?`ö    ?        	.??I?  I? Opacity$ 1Q?.???  ? Brush ?	#FF000000 ? Geometry? ??`ö`ö?        ??a[?  ?P?? ?  h?? ?a[?    ?:h?? x???a[x????>x??`ö?:`ö?a[?`öh?? ?>?  ?a[?  ??a[??g Ӱۚ??g ?K??U? ?K???? ӨK??=?ۚ??M?a[??MӀ???M?? ?=?? ??? ӈ? ?U? ????g ?a[??g ?(N[x?[? ?x?[`?  ?D(J? ???e? ?j?? h??? @~?Ӹ? ?%??/?  ??P? ????>? ???X?? ?????%???@~?Ә?P???fV?????? ?D??x?[(N[x?[?? -
   $ 
TaskButton??$??70??$	??150??$??1??#???  $
??Left=?$??5q?.???? $??0??$??18(?
???   ?$??Center=?$??Задания???? $??1??$??1??$??2q???H?  I? 4 ??        ?    ?UјU?UјU    ?        	.??I? $ 1Q?.???  ?	#FF000000? ???U?U?        ?h?@KF? @C@KFѰ???y Ӱx?2 x????}?8:?    ӈBH    ?9	x?2 P[?
??y ?x?
@KF???l@KF??:?@KFHL??X?HL?0?,?HL???(?HL??K??:??Y??l?Y??k??Y?(?;?Y ??K? ???(? ?0?,?8??X?@?;@KFh?@KF??£??(??£@???[08*h?8*??l8*Ӹ??8*??k@????k??(???k0?,???k????????+?l??+? @`
??+ѠnF
0?????;
???`G
?v???P@@?d
P?"?`^?
??G +?
0(]?M?
0(]?X?00(]Ӑ&`0(]h????G?N?P?"??????O??????0??Ѱ???+?h???+??[0??+?£? ??£0?,??£??(?  ?	#FF000000? ???U?U?        ?8?.
';Ѡ??';?H?%?
?8yH 9
????
	?ɦ??-?H?=??P?kxZH.I????xcxL??xc8?xc??????-?????-?8?.
??-??ض	??-8sU	??8sU	8?8sU	оa
?8sU	H??
?ض	';8?.
';?  ?	#FF000000? ???U?U?        ??Q(>??0??]c	Ѱ;??wӨRK+?ٺ??Gxo?????o#?'%	(??x?	?Ǯ?
?ȗ?`}b?????~`??Ɍ?S3?Ɍ??ʡE?/p@?Ɍ??(\?np@?Kv?z?G?p@?QJ???`0??ӀY?Ȏ??\?????mj????p@V;??t?/7?Q(>??  ?	#FF000000? ???U?U?        ?8?.
??? ?????H?%P?R?8yH?Ļ??č?ɦ?s??H?=?:??k??H.I@l1?xc?C?xcp???xc????0?????0???8?.
0????ض	0??8sU	??8sU	p???8sU	H???8sU	??\?ض	??8?.
???  ?	#FF000000? ???U?U?        ??Q?$?0?%?Ѱ;?8??ӨR(???ٺ???xoK9??o#??(????>?Ǯ@??ȗ??H????ع`????S3????ʡE?/p@????(\?np@??z?G?p@????`??vӀY?Xu?\?????mj(??p?8???t?1??Q?$?  ?	#FF000000? ???U?U?        𨶉?c3?8?.
?c3??ض	?c38sU	pɔ8sU	??8sU	?lg?8sU	Xo??ض	??@8?.
??@Ѩ????@?????@xcXo?xc?lg?xc??xcpɔ???c3????c3? $??0??$??3?? ??%?   &	       &	      7  &	 l     7  X?155Q??? .??W? $8 2(UIElement.RenderTransform).(TranslateTransform.X)? 08   $ 0:0:0.3D??? .??W? $8 2(UIElement.RenderTransform).(TranslateTransform.X)?8    0$ 0:0:0.3D?.+??? $	??200??$	??250??$ 0,0,80,0??$??
-310 0 0 0q?$	??Top=?   $ 5Q?$	 270Q?$ Black??$		 0.5Q?$
 7Q????? " ?? ??  ?? Binding ?? *	IsChecked+  ?? ElementName$  
SlideState??! ?? Value! True" N? EnterActions" ?? #??[ # N? ExitActions# ?? #??[ ???? $ ?? 
StartPoint$	$ 0,0&?% ?? EndPoint$	% 1,0&???? & ? Offset$& 0Q?' ? Color$' #0F2027??? $
& 0.35Q?$' #203A43??? $
& 0.65Q?$' #203A43??? $& 1Q?$' #2C5364??z?T? ._??  ?? $	??20* ??? $??5* ??? $??5* ?.+?d? -   ( d?Name$( 
SlideState??$??40??$??40??$	??5 0q?
?????? $??Right=?$	??Top=?$??0q?  ImageButtonTog#???  .???? ??H?  I? 4 ??        ?     ?J? ?J ?J? ?J    ?        	.??I? $ 1Q?.??? 
) ? Pen) >? * >? Brush* ?	#FF000000+ >? 	Thickness$+ 4Q?, >? StartLineCap$, Round=?- >? 
EndLineCap$- Round=?. >? LineJoin$. Round=?/ >? 
MiterLimit$/ 10Q? ?? 0 ?? 
StartPoint$0 16,26&?1 ?? EndPoint$1 56,26&?? ) >? * ?	#FF000000$+ 4Q?$, Round=?$- Round=?$. Round=?$/ 10Q? ?? $0 16,36&?$1 56,36&?? ) >? * ?	#FF000000$+ 4Q?$, Round=?$- Round=?$. Round=?$/ 10Q? ?? $0 16,46&?$1 56,46&?A? -   2 A?Name$2 
PhotoUsers??$	??150??$	??150??$
??Left=?$??5 0 0 0q????? 3 ?? ImageSource3 ?? *CurrentUserPhoto+?? -   $ 	NameBlock??$??5q?$??1??
???   ?$??18(?$
??Left=?$??Center=????? *Name+?? -   $ SurnameBlock??$??5q?$??2??
???   ?$??18(?$
??Left=?$??Center=????? *	Surname+?? -   $ LogOut??$??40??$??40??$??10q?$??Right=?$	??Top=?$??3??$??0q?  ImageButton#???  .???? ??H?  I? 4 ??        ?    ?G3??G3?G3??G3    ?        	4 I? 	Transform4 T? 5 T? X$5 0Q?6 T? Y$6 3.5527136788005009E-15Q?.??I? $ 1Q?.??I? $ 1Q?.??I? $ 1Q?.???  ?	#FF000000? ???G3?G3?        ?????2?Ӏ7? ?=?7? ?= ???%<? R? 6??? w1 ???\+??y? ?)?y?`O(` ???&Ӡ?@? ??????@y?????`5 l`5 lӠB?Q?O 7 ]???? ]@? ]@??????? ? n??w ?????+????@?????????? ??}?`?  c?`? ????`? ???`?  .? &"? ?Ӡ?#@???#???@3%@Ѳ???&?????&`???&??????&ฏ??&??@3% ?~?@3%??x??# ?r &"??l? &"@?i &"?h`? `?d??@^] ??CW???OӀ N?`?L??`?L?@?@?D ???>???87??? ?5?? ?5 ]`+4??O?.?B?o&`5@U ?`5???? H?? HӀ??-@?  ` ???
??y??q	?y?@? ???d?@_? J  R??/? ?????Ӏ7? ??7? ????????`?? t??????`a?`???@I??&??`? ??@?? ??`?&?ӀC?ba?C??	`??m	?`?????? g'???Ӡq?????? ?q	?? ???Ӏ?  ?)?q??????ap@ g'?????ap@Q 	??????ap@? ?? ???@k"??#@k" D? ???0?????b@%? ?|?HA ?|?@l? ?|?????b`???0??????TS?{??????	p@`??@ME????2??  ?	#FF000000? ???G3?G3?        ??%?``??E:``?@;?```?@@??`?@?s?`?@ ~u @;??????????E:????????Q?%??????????@_?     ?@?} ????? ? ??? ??v?@_??G3?%??G3??:?G3? 0??G3@? ?ɽ@?  [.?@? ?e? 0???'?:??'??%???'?`ê??'`???`? ???`????? u???`ê``?%?``
   M S B A M L   `   `   `  ????I  EASMaIoP.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ASMaIoP.Client.ViewASMaIoP.Client.View  5   	   $    ASMaIoP.Client.View.AuthWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ASMaIoP.Client.View     5   	   -   5        ???	#01000000  ? AllowsTransparency$
  True??5   	    ? WindowState$ 	Maximized=?5	   	    ? WindowStyle$
 None=?5
   	    ? 
ResizeMode$ NoResize=?5   	   $??20(?5   	    ? WindowStartupLocation$ CenterScreen=?5   	   $
??1040??5   	   $
??1440??6   .??5      ?? ._?5   
   ? $??Center=?5   	   $??Center=?5   	   $	??400??5   	   $	??400??5   	    ? ColumnDefinitions 5      ?? 5      $
??101* ?6#   ?? 5      $	??99* ?6#   .+?5      ??  ?? CornerRadius$ 20??5      ???#0bd2c4 J? Opacity$ .5Q?5      $??2??6   ?? 5      $	??300??5        ?? Orientation$ Vertical=?5!      $??
50,86,0,24q?5"      $
??Left=?5#      $??2??6(   .+?5$      ?? $??Логин:??5%      $??	10,5,10,0q?5&      ?? 5'         TextBoxRound#???   6   $??50??5(      $??	10,5,10,0q?5*      
?????? $??Center=?5+   *   $
??10,0q?5,      ??5)      ?? 	 ?? Path$	 Login?.??5,       
 ? 	Resources
 5-       ?? 
TargetType ?? Property ?? Value??%_   '??       ?? 5.      " ??6    .?5/      ??  ?@??CornerRadius$ 15??6=   50      51      .??6)   52      ?? 53      $??Пароль:??54      $??	10,5,10,0q?55      G? 56      -   5         G?Name$ PswBox??57      $??50??56        PasswordBoxRnd#???  58      $??	10,5,10,0q?59      
?????? $??Center=?5:   *   $
??10,0q?5<      5=      ?? 5>      -   5         ??Name$ LoginButton??5>      $??10q?5?      $??40??5@      $	??100??5A      $??
Войти??5B      
 5D      ??%_   '??       ?? 5E      " ??6    .?5F      ??  ?@??CornerRadius$ 15??6=   5G      5H      5I      ?? 5J      -   5        $ Close_Program??5J      
???  ??$??10q?5L      $??40??5M      $??80??5N      .??5P      Закрыть6   5Q      5R      5S      5T      
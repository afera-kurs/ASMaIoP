   M S B A M L   `   `   `  ???? I  EASMaIoP.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ASMaIoP.Client.View.PagesASMaIoP.Client.View.Pages  E'clr-namespace:ASMaIoP.Client.ViewModelsASMaIoP.Client.ViewModels  *    $ASMaIoP.Client.View.Pages.TabelRight   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9local'clr-namespace:ASMaIoP.Client.View.Pages     >
viewmodels'clr-namespace:ASMaIoP.Client.ViewModels     .??? .+?&   System.Windows.Controls.DataGrid  -      Name$  TabelDataGrid??
??????    RowBackground
 ????    AutoGenerateColumns$ False??   
IsReadOnly$
 True??$??20q????? *TabelColumn+   ColumnHeaderStyle ??  ?? 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .???  ?? Property ? ?? ?? Value
 ???? ??  ? ??$
 Bold"?   RowHeaderStyle ?? :  4System.Windows.Controls.Primitives.DataGridRowHeader"  .???  ? ??
 ???? 	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Номер??   Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 1  +System.Windows.Controls.DataGridBoundColumn   Binding ??  ?? Path$ ID?  $
 Работник??$	 100  ?? $ Employee?  $
 Должность??$	 100  ?? $
 Role?  $
 Прибыл??$	 150  ?? $ Comes?  $
 Покинул??$	 150  ?? $ Leave?
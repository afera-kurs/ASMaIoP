   M S B A M L   `   `   `  ????I  EASMaIoP.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ASMaIoP.Client.View.PagesASMaIoP.Client.View.Pages  5      E'clr-namespace:ASMaIoP.Client.ViewModelsASMaIoP.Client.ViewModels  6D   *    $ASMaIoP.Client.View.Pages.TabelRight   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:ASMaIoP.Client.View.Pages     5      >
viewmodels'clr-namespace:ASMaIoP.Client.ViewModels     6D   .??5
      ? .+?5   
   &   System.Windows.Controls.DataGrid  -   5           Name$  TabelDataGrid??5      
??????    RowBackground
 ????    AutoGenerateColumns$ False??5         
IsReadOnly$
 True??5      $??20q?5      ??5      ?? *TabelColumn+   ColumnHeaderStyle 5      ?? 5       ?? 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .?5      ??  ?? Property ? ?? ?? Value
 ???? 63   ?? 5       ? ??$
 Bold"?63   5         RowHeaderStyle 5      ?? 5      :  4System.Windows.Controls.Primitives.DataGridRowHeader"  6   .?5      ??  ? ??
 ???? 63   5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Номер??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   ??  ?? Path$ ID?6P     5       $
 Работник??6%   $	 100 6Y    67   ?? $ Employee?6Y     5!      $
 Должность??6%   $	 100 6V    68   ?? $
 Role?6V     5"      $
 Прибыл??6%   $	 150 6T    65   ?? $ Comes?6T     5#      $
 Покинул??6%   $	 150 6U    66   ?? $ Leave?6U   5%      5&      5'      
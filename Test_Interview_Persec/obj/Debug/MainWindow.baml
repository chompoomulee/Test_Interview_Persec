   M S B A M L   `   `   `  ????P  LTest_Interview_Persec, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Test_Interview_PersecTest_Interview_Persec  5   	   &     Test_Interview_Persec.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2gif"http://wpfanimatedgif.codeplex.com     5   	   5local#clr-namespace:Test_Interview_Persec     5   	     ? Title$  
MainWindow??5	   	   $	??450??6   $	??800??6)   .??5      ? .+?5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ 	StartDate??5      $
??Left=?6(   $??	43,55,0,0q?6C   $	??Top=?6V    ? 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox ?? 
TargetType ?? Property ?? Value ?? Path ?? StringFormat ?? RelativeSource	 ?? AncestorType??%?   '        ?? 5      "  6   .?5      ??  ?@??
IsReadOnly . 63   ?? 5       ? ?? 6-   ?? $ SelectedDate?$ yyyy/MM?? ?? $	 
DatePickerL?6?   5      5      5      ?? 5   
   $??
Start Date??6   $
??Left=?6%   $??	43,29,0,0q?6@   $	??Top=?6S     5   
   -   5        $ EndDate??5      $
??Left=?6&   $??
166,55,0,0q?6A   $	??Top=?6U    5      ??%?   '        ?? 5      "  6   .?5      ??  ?@??
IsReadOnly . 63   ?? 5       ? ?? 6-   ?? $ SelectedDate?$ yyyy/MM?? ?? $	 
DatePickerL?6?   5      5      5      ?? 5   
   $??End Date??6   $
??Left=?6#   $??
166,29,0,0q?6>   $	??Top=?6R   ?? 5   
   -   5        $??Search??5      $
??Left=?6"   $??
290,57,0,0q?6=   $	??Top=?6Q   $??82??6~   &   System.Windows.Controls.DataGrid  5   
   -   5        $??dataList??5      $y?	Collapsed=?6N   $??22,112,128,18q?6e   
   AutoGenerateColumns
 .  $??Stretch=?6?   $??Stretch=?6?      Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$	 No.??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   ?? $ No?6[     5"      $ Title??6%   $	 150 6S    64   ?? $ Title?6a      RowDetailsTemplate 5$      ?? 5%      .R?5&      ?? $??0q?6   
??????? ?? Padding$ 10q?6M   ._?5'      ??  ?? Orientation$ Vertical=?6%   .+?5(      ?? $ 
Horizontal=?6)   .+?5)   "   ?? $??Center=?5*   %   $	??210??5+   %   $??Center=?5,   %   $	??335??5-   %   ??5)   (   ?? *Url+5.   #   5/      ?? 50      $ 
Horizontal=?6)   .+?51   "   ?? $??12(?6,   $??Explanation: ??6:   $??Center=?6O   ?? 52   "   $??16(?6,   
???p?$??Center=?6q   ??6T   ?? *Explanation+6q   53      54      55      56      58      ?? 59   
   -   5        $??Error??59      $
??Left=?6!   $??
45,104,0,0q?6<   $
??Wrap=?6P   $?? ??6d   $y?	Collapsed=?6l   $	??Top=?6?   5:      5;      
   M S B A M L   `   `   `  ����R  NPrideTek.EmployeeModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PrideTek.EmployeeModulePrideTek.EmployeeModule  5      Y UPrideTek.EzSale.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullwTclr-namespace:PrideTek.EzSale.Infrastructure;assembly=PrideTek.EzSale.InfrastructurePrideTek.EzSale.Infrastructure 5      Q MPrideTek.EzSale.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullqMclr-namespace:PrideTek.EzSale.Models.Entities;assembly=PrideTek.EzSale.ModelsPrideTek.EzSale.Models.Entities 5	      N JPrideTek.Shell.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:PrideTek.Shell.Core;assembly=PrideTek.Shell.CorePrideTek.Shell.Core 5      +    %PrideTek.EmployeeModule.EmployeesView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:PrideTek.EmployeeModule     5      dinfTclr-namespace:PrideTek.EzSale.Infrastructure;assembly=PrideTek.EzSale.Infrastructure     5      P LPrism.Wpf, Version=6.2.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8$prismhttp://prismlibrary.com/  5      XdataMclr-namespace:PrideTek.EzSale.Models.Entities;assembly=PrideTek.EzSale.Models  5	      c	 _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Cie:http://schemas.microsoft.com/expression/2010/interactivity 	 5
      O
converters>clr-namespace:PrideTek.Shell.Core;assembly=PrideTek.Shell.Core 	 5        � 	Resources  5      3  -PrideTek.Shell.Core.DebugDataBindingConverter   DebugDataBindingConverter��%   &	          5   
   6/   5      .��5      � -   5        $��MainGrid��5       � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��8* �6   �� 5      $��20 �6   .+�5   
   � $��0��6   
����ح�$��0,-5,0,5q�63    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5       $��1* �6#   .+�5"      �� $��0��6   
�������$��20(�6W   ��6$   �� *
ViewHeader+6W   �� 5#      -   5        $��AddEmployee��5#      $��3��6(   $��+��68   $��15(�6D   $��Center=�6S   $��Center=�6p   .  (PrideTek.EzSale.Infrastructure.ViewNames   EmployeeAddView#��Z 6�   ��6�   �� *
NavCommand+6�   5$      � 5&   
   -   5        $��
SearchGrid��5&      $��1��6!   $
��50px��6.    5'      �� 5(      $��2* �6#   �� 5)      $��1* �6#   �� 5*      $��1* �6#   �� 5+      $��1* �6#   .+�5.      �� -   5        $��
SeachInput��5.      $��0��6(   $��8q�68   �� 5/      $��1��6   $��8q�6(   1  +PrideTek.EzSale.Infrastructure.ComboBoxData   SortByPropertyValues#��Z 63    �� SelectedItem 6r   �� *SortByPropertyValue+ �� UpdateSourceTrigger$ PropertyChanged=��� 50      $��2��6   $��8q�6'      SortByEntityState#��Z 62    6n   �� *SortByState+$ PropertyChanged=��� 51      $��3��6   $��8q�6%   ��52      �� 53       �� Orientation$ 
Horizontal=�6!   .+�54      �� $E��?/PrideTek.EzSale.Infrastructure;Component/images/SearchIcon.jpg��6    �� 55      $��Search��6    $��1q�61   56      58      5:      �� 5;   
   $��1��6   $��Bottom=�6!   � 5<   
   -   5        $��ContentGrid��5<      $��2��6"   .+�5=      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 EmployeeDataGrid��5=      
   CanUserAddRows
 .     RowDetailsVisibilityMode$ VisibleWhenSelected=�6�      AutoGenerateColumns .  $ �� IsSynchronizedWithCurrentItem$ FalseY�6�   ��62   �� *EmployeeCollection+ �� Mode$ TwoWay=�$ PropertyChanged=� J� InputBindings 5>      d� 5?       d� MouseAction$ LeftDoubleClicke�5@       �� Command 5A      �� *SelectedItemSelectedCommand+ �� CommandParameter 5B      ��  �� ElementName$ EmployeeDataGrid�� �� Path$ SelectedItem�   	CellStyle 5D      �� 5E       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    �� Triggers 5F      P� 5G       P� Property �@J�IsMouseOver P� Value . . �5I   "   ��  �� Property � �� �� Value
 �����5J      5K      5M         RowStyle 5`      �� 5a      )  #System.Windows.Controls.DataGridRow"  6   .�5b      ��  � ��
 �����67   �� 5c       � ��$ Normal"�67    5d      �� 5e       �� Binding 6*   �� *	IsDeleted+ �� Value True6H   .a�5f   "   ��  � ��
 �  ��6M   5g      P� 5h       �@ AlternationIndex$ 1��6B   . �5i   "   ��  � ��
 �����6?   �� 5j   "    � ��$
 Bold"�6?   5k      P� 5l       �@J�IsMouseOver . . �5m   "   ��  � ��
 �����6?   5n      5p         Columns 5s      4  .System.Windows.Controls.DataGridCheckBoxColumn  5t      ,  &System.Windows.Controls.DataGridColumn    CanUserSort  .  !   
IsReadOnly! .  1	  +System.Windows.Controls.DataGridBoundColumn" 	  Binding" 6T   �� *
IsSelected+$ TwoWay=�$ PropertyChanged=�#   HeaderTemplate# 5u      �� 5v      .R�5w   "   �� 
������ ��6)   �� *DataContext.DeleteCommand+$ �� RelativeSource$ �� % �� AncestorType$% DataGridL�& �� 	Converter#& [  ��5x   &   �� 5y   *   .+�5z   .   �� $@��:/PrideTek.EzSale.Infrastructure;Component/images/Trash.jpg��64   $
��50px��6x   $
��30px��6�   5{   +   5}   #   5~      5�      0
  *System.Windows.Controls.DataGridTextColumn
  5�      ! . -   5        
nameColumn��'   Header$' 
First Name��5�   n   (   Width5  /System.Windows.Controls.DataGridLengthConverter$( 0.25* 6�   " 6P   �� *	FirstName+6�   
  5�      ! . -   5        AccessPermissionColumn��$' Access Permision��5�   �   $( 0.25* 6�   " 6\   �� *AccessPermission+6�   
  5�      ! . -	   5        CellPhoneColumn��$' Email��5�   o   $( 0.25* 6~   " 6U   �� *Email+6~   
  5�      ! . -
   5        lastNameColumn��$' 
Cell phone��5�   q   $( 0.25* 6�   " 6S   �� *	CellPhone+6�   
  5�      ! . -   5        emailColumn��$' Employee code��5�   l   $( 0.25* 6�   " 6P   �� *	PinCode+6�   5�      5�      � 5�   
   -   5        $��InfoGrid��5�      $��3��6   5�      5�      5�      
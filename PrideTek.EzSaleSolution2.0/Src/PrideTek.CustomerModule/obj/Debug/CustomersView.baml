   M S B A M L   `   `   `  ����R  NPrideTek.CustomerModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PrideTek.CustomerModulePrideTek.CustomerModule  5      Y UPrideTek.EzSale.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullwTclr-namespace:PrideTek.EzSale.Infrastructure;assembly=PrideTek.EzSale.InfrastructurePrideTek.EzSale.Infrastructure 5      Q MPrideTek.EzSale.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullqMclr-namespace:PrideTek.EzSale.Models.Entities;assembly=PrideTek.EzSale.ModelsPrideTek.EzSale.Models.Entities 5	      N JPrideTek.Shell.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:PrideTek.Shell.Core;assembly=PrideTek.Shell.CorePrideTek.Shell.Core 5      +    %PrideTek.CustomerModule.CustomersView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:PrideTek.CustomerModule     5      dinfTclr-namespace:PrideTek.EzSale.Infrastructure;assembly=PrideTek.EzSale.Infrastructure     5      P LPrism.Wpf, Version=6.2.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8$prismhttp://prismlibrary.com/  5      XdataMclr-namespace:PrideTek.EzSale.Models.Entities;assembly=PrideTek.EzSale.Models  5	      c	 _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Cie:http://schemas.microsoft.com/expression/2010/interactivity 	 5
      O
converters>clr-namespace:PrideTek.Shell.Core;assembly=PrideTek.Shell.Core 	 5        � 	Resources  5      3  -PrideTek.Shell.Core.DebugDataBindingConverter   DebugDataBindingConverter��%   &	          5   
   6/   5      .��5      � -   5        $��MainGrid��5       � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��8* �6   �� 5      $��20 �6   .+�5   
   � $��0��6   
����ح�$��0,-5,0,5q�63    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5!      �� $��0��6   $��	Customers��6$   
�������$��20(�6L   �� 5"      -   5         ��Name$ AddCustomer��5"      $��3��6*   $��+��6:   $��15(�6F   $��Center=�6U   $��Center=�6r   .  (PrideTek.EzSale.Infrastructure.ViewNames   CustomerAddView#��Z 6�   ��6�   �� *
NavCommand+6�   5#      � 5%   
   -   5        $��
SearchGrid��5%      $��1��6!   $
��50px��6.    5&      �� 5'      $��2* �6#   �� 5(      $��1* �6#   �� 5)      $��1* �6#   �� 5*      $��1* �6#   .+�5-      �� -   5        $��
SeachInput��5-      $��0��6(   $��8q�68   �� 5.      $��1��6   $��8q�6(   1  +PrideTek.EzSale.Infrastructure.ComboBoxData   SortByPropertyValues#��Z 63    �� SelectedItem 6r   �� *SortByPropertyValue+ �� UpdateSourceTrigger$ PropertyChanged=��� 5/      $��2��6   $��8q�6'      SortByEntityState#��Z 62    6n   �� *SortByState+$ PropertyChanged=��� 50      $��3��6   $��8q�6%   ��51      �� 52      	 �� Orientation$	 
Horizontal=�6!   .+�53      �� $E��?/PrideTek.EzSale.Infrastructure;Component/images/SearchIcon.jpg��6    �� 54      $��Search��6    $��1q�61   55      57      59      �� 5:   
   $��1��6   $��Bottom=�6!   � 5;   
   -   5        $��ContentGrid��5;      $��2��6"   .+�5<      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 CustomersDataGrid��5<         CanUserAddRows .     RowDetailsVisibilityMode$ VisibleWhenSelected=�6�      AutoGenerateColumns .  $ �� IsSynchronizedWithCurrentItem$ FalseY�6�   ��63   �� *CustomerCollection+ �� Mode$ TwoWay=�$ PropertyChanged=� J� InputBindings 5=      d� 5>       d� MouseAction$ LeftDoubleClicke�5?       �� Command 5@      �� *SelectedItemChangedCommand+ �� CommandParameter 5A      ��  �� ElementName$ CustomerDataGrid�� �� Path$ SelectedItem�   	CellStyle 5C      �� 5D       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    �� Triggers 5E      P� 5F       P� Property �@J�IsMouseOver P� Value . . �5H   "   ��  �� Property � �� �� Value
 �����5I      5J      5L         RowStyle 5N      �� 5O      )  #System.Windows.Controls.DataGridRow"  6   .�5P      ��  � ��
 �����67   �� 5Q       � ��$ Normal"�67    5R      �� 5S       �� Binding 6*   �� *	IsDeleted+ �� Value True6H   .a�5T   "   ��  � ��
 �  ��6M   5U      P� 5V       �@ AlternationIndex$ 1��6B   . �5W   "   ��  � ��
 �����6?   �� 5X   "    � ��$
 Bold"�6?   5Y      P� 5Z       �@J�IsMouseOver . . �5[   "   ��  � ��
 �����6?   5\      5^          Columns  5a      4  .System.Windows.Controls.DataGridCheckBoxColumn  5b      ,  &System.Windows.Controls.DataGridColumn!   CanUserSort! .  "   
IsReadOnly" .  1	  +System.Windows.Controls.DataGridBoundColumn# 	  Binding# 6T   �� *
IsSelected+$ TwoWay=�$ PropertyChanged=�$   HeaderTemplate$ 5c      �� 5d      .R�5e   "   �� 
������ ��6)   �� *DataContext.DeleteCommand+% �� RelativeSource% �� & �� AncestorType$& DataGridL�' �� 	Converter#' [  ��5f   &   �� 5g   *   .+�5h   .   �� $@��:/PrideTek.EzSale.Infrastructure;Component/images/Trash.jpg��64   $
��50px��6x   $
��30px��6�   5i   +   5k   #   5l      5n      0
  *System.Windows.Controls.DataGridTextColumn
  5p      " . -   5        
nameColumn��(   Header$( 
First Name��5p   n   )   Width5  /System.Windows.Controls.DataGridLengthConverter$) 0.25* 6�   # 6P   �� *	FirstName+6�   
  5q      " . -   5        AccessPermissionColumn��$( Access Permision��5q   �   $) 0.25* 6�   # 6\   �� *AccessPermission+6�   
  5r      " . -	   5        CellPhoneColumn��$( Email��5r   o   $) 0.25* 6~   # 6U   �� *Email+6~   
  5s      " . -
   5        lastNameColumn��$( 
Cell phone��5s   q   $) 0.25* 6�   # 6S   �� *	CellPhone+6�   
  5t      " . -   5        emailColumn��$( Customer code��5t   l   $) 0.25* 6�   # 6P   �� *	PinCode+6�   5v      5w      � 5y   
   -   5        $��InfoGrid��5y      $��3��6   5{      5|      5~      
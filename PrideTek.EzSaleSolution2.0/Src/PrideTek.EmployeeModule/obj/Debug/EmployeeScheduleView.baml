   M S B A M L   `   `   `  ����R  NPrideTek.EmployeeModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:PrideTek.EmployeeModulePrideTek.EmployeeModule  5      Y UPrideTek.EzSale.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullwTclr-namespace:PrideTek.EzSale.Infrastructure;assembly=PrideTek.EzSale.InfrastructurePrideTek.EzSale.Infrastructure 5      2    ,PrideTek.EmployeeModule.EmployeeScheduleView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:PrideTek.EmployeeModule     5      dinfTclr-namespace:PrideTek.EzSale.Infrastructure;assembly=PrideTek.EzSale.Infrastructure     5      .��5
      � -   5        $��MainGrid��5
        � RowDefinitions  5   
   �� 5      $��30 �6   �� 5      $��60 �6   �� 5      $
��auto �6   �� 5      $��60 �6   �� 5      .+�5   
   � $��0��6   
����ح�.+�5      �� $��Employee Schedule��6   $	��120��60   $
��Left=�6<   $��10,0,0,0q�6W   5      �� 5   
   $��0��6   $��3��6!   $��Bottom=�65   � 5   
   $��1��6   
��� ��� � ColumnDefinitions 5      �� 5      $	��400 �6#   �� 5      $	��400 �6#   �� 5      $	��250 �6#   .+�5%      � $��0��6   $��10,0,0,0q�6#     5&      �� 5'      $��1* �6$   �� 5(      $��1* �6$   .+�5+      �� $��0��6   $��Select week��6%   $
��Left=�6;   (  "System.Windows.Controls.DatePicker  5,      $��1��6   $	��300��6*   $��25��66   $
��Left=�6C   5-      � 50      $��1��6   $��30,0,0,0q�6#     51      �� 52      $��1* �6$   �� 53      $��1* �6$   .+�56      �� $��0��6   $��Employee��6%   $
��Left=�68   �� 57      $��1��6   $	��300��6)   $��25��65   $
��Left=�6A   58      � 5:      $��2��6   $��	30,0,20,0q�6#     5;      �� 5<      $��1* �6$   �� 5=      $��1* �6$   .+�5?      �� $��0��6   $��Generate��6)   $
��Left=�6<   �� 5@      $��1��6   $	��200��6*   $��25��67   $
��Left=�6C   .��5A      ��  �� Orientation$ 
Horizontal=�6%   .+�5B      �� $H��B/Pridetek.EzSale.Infrastructure;Component/Images/download_icon.png��6$   $��20��6q   $��20��6|   �� 5C      $��Export to Excel��6$   $��9(�6>   5D      5E      5F      5G      � 5I   
   -   5         �Name$ ScheduleGrid��5I      $��2��6%   
���  ��  5J      �� 5K      $��60 �6    �� 5L      $	��400 �6    �� 5M      $��60 �6    .+�5P      � $��0��6   
����ح�$��10,0,0,0q�67     5Q      �� 5R      $��1* �6$   �� 5S      $��1* �6$   .+�5V      �� $��0��6   $��Magic schedule setup��6%   �� 5W      $��1��6   $	��200��6(   $
��Left=�64    �� 
IsEditable .  1  +PrideTek.EzSale.Infrastructure.ComboBoxData   MagicScheduleValues#��Z 6b   
�������$��	0,-10,0,0q�6�   5X      5Z      5b      5c      
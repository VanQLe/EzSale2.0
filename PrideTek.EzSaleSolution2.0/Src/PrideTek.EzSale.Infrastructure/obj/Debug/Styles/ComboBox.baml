   M S B A M L   `   `   `  ����Y  UPrideTek.EzSale.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:PrideTek.EzSale.Infrastructure.Styles%PrideTek.EzSale.Infrastructure.Styles  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ComboBoxToggleButton  �� 
TargetType � ColumnDefinitions'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� Duration	 W� To �� TargetProperty �� 
TargetName  DisabledOpacity	   Transitions%  System.Windows.VisualTransition
   GeneratedDuration   GeneratedEasingFunction/  )System.Windows.Media.Animation.CircleEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode ��Name �� CornerRadius J� Opacity F�Name �� Stretch � UseLayoutRounding  ControlHoverBorderBrush  ControlFocusBorderBrush  ComboBoxTextBox  	ComboBox1 �� 
TargetType �� Property �� Value  ControlBackground  ControlBorderBrush  ControlFontFamily 	 ControlFontSize 
 ControlForeground  ControlHeight R� KeyTime  System.Windows.Visibility   Visible R� Value   Hidden d�Name �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource ��Name  J� IsHitTestVisible! �� SelectionBoxItem" �� SelectionBoxItemTemplate# ��Name  AccentBrush1_1$ �� 
CaretBrush% �� 
IsReadOnly& �� 
IsReadOnly' �Name( �� IsDropDownOpen) J� SnapsToDevicePixels* � AllowsTransparency+ �Name, � ActualWidth- �� MaxDropDownHeight  PopupBorderBrush  PopupBackground. J� Effect3  -System.Windows.Media.Effects.DropShadowEffect/   Opacity0   ShadowDepth  DropShadowColor_Invariant1   Color2   
BlurRadius3 K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation4   DirectionalNavigation5 �� Triggers6 P� Property7 P� Value8 �� 
TargetName9 P� 
SourceName  ComboBoxItem1  Foreground2: O� KeyTime; O� Value  HoverBrush2   SelectedBackground_Invariant  SelectedBorder_Invariant< ��Name  Foreground1_White= �� BasedOn�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      =local3clr-namespace:PrideTek.EzSale.Infrastructure.Styles  5      %�  &	        &	 �	    &	 �	    7   7  &	 Z    '��     7  '�� 9    7  �� 5      "  d�63   .R�5   
   �  5      �� 5      �� 5	      $��20 �6#    5        5      CommonStates��. 5        
Normal��6"     5      	MouseOver��. 5      �� .��5      W� $ 0D�6.   $ 1X�6;   $ (UIElement.Opacity)�6B   $ 
ArrowHover��6r   W� 5      $ 0D�6.   $ 1X�6;   $ (UIElement.Opacity)�6B   $ BorderHover��6r   5      5        5      Pressed��6"     5      Disabled��. 5      �� .��5      W� $ 0D�6.   $ Border��6<   $ Opacity�6[   # �  6   W� 5      $ 0D�6.   $ Arrow��6<   $ Opacity�6Z   # �  6~   5      5      5        5      CheckStates��. 5        Checked��. 5      �� .��5       W� $ 0D�6.   $ 1X�6;   $ (UIElement.Opacity)�6B   $ BorderFocused��6r   W� 5!      $ 0D�6.   $ 1X�6;   $ (UIElement.Opacity)�6B   $ ArrowFocused��6r   5"      5#        5$      	Unchecked��6"     5%      Indeterminate��6"   5&        5'      FocusStates��	 5(        5)      $
 0:0:0.3D�6+    5*        5+   "   $ EaseOut=�6-   5-      . 5/        Focused��. 50      �� .��51      W� $ 0D�6.   $ 1X�6;   $ (UIElement.Opacity)�6B   $ BorderFocused��6r   W� 52      $ 0D�6.   $ 1X�6;   $ (UIElement.Opacity)�6B   $ ArrowFocused��6r   53      54        55      	Unfocused��6"   56      .+�58      �� $ Border��6   $��2��6%   $ 3��69   #��z��6J   ���#CCCCCC#��z��6�   �� 59      $ BorderHover��6   $��2��6*   $ 3��6>   #��z��6O   ���#CCCCCC#��z��6�   $ 0Q�6�   �� 5:      $ BorderFocused��6   $��2��6,   $ 3��6@   #��z��6Q   ���#CCCCCC#��z��6�   $ 0Q�6�   F� 5;      $ Arrow��6   "����        �@T�     � �D ��j 	$
 Fill=�6<   #��z��6K    .  $��7��6�   $��Center=�6�   $��Right=�6�   $��9��6�   $��0,1,5,0q�6�   $��1��6�   F� 5<      $ 
ArrowHover��6   "����        �@T�     � �D ��j 	$
 Fill=�6A   #���  6P    .  $��7��6�   $��Center=�6�   $��Right=�6�   $��9��6�   $��0,1,5,0q�6�   $ 0Q�6�   $��1��6  F� 5=      $ ArrowFocused��6   "����        �@T�     � �D ��j 	$
 Fill=�6C   #���  6R    .  $��7��6�   $��Center=�6�   $��Right=�6�   $��9��6�   $��0,1,5,0q�6�   $ 0Q�6�   $��1��6  5>      5?      �� 5C      "  ��6.   .R�5D   
   �� $ PART_ContentHost��6   |�.  #��z��6=   5E      �� 5G      " ��6   .�5H   
   ��  �@J�SnapsToDevicePixels . 60   �� 5I   
    �@�OverridesDefaultStyle . 62   �� 5J   
    � ��$
 Auto=�6G   �� 5K   
    � ��$
 Auto=�6E   �� 5L   
    � �� . 6:   �� 5M   
    � ��$	 350��6"   �� 5N   
    � ��$ 35��6#   �� 5O   
    � ��$	 120��6%   �� 5P   
    � ��$ 22��6&   �� 5Q   
    � ��# �  6'   �� 5R   
    � ��# �  6(   �� 5S   
    � ��# �  6'   �� 5T   
    � ��# � 	 6%   �� 5U   
    � ��# � 
 6'   �� 5V   
    � ��# �  6#   �� 5W   
    � ��$ 1q�6,   �� 5X   
    � ��$ Stretch=�60   �� 5Y   
    � ��$ Stretch=�6.   �� 5Z   
    �@��IsTextSearchEnabled .  60   �� 5[   
    � �� 5\      �� 5]      "  ��6"   .R�5^      �  5_        5`      CommonStates��. 5a   "     
Normal��6.     5b   "   	MouseOver��6.     5c   "   Disabled��. 5d   &   �� .��5e   *   W� $ 0D�6:   $ PART_EditableTextBox��6H   $ Opacity�6u   # �  6�   5f   '   5g   #   5h        5i      
EditStates��. 5j   "     Editable��. 5k   &   �� .��5l   *   T� $ (UIElement.Visibility)�6H   $ PART_EditableTextBox��6{   ..�5m   .   i� $ 0��6E   # Z 6Q   5n   +   T� 5o   *   $ (UIElement.Visibility)�6H   $ ContentSite��5p   2   ..�5q   .   i� $ 0��6E   # Z 6Q   5r   +   5s   '   5t   #     5u   "   
Uneditable��6.   5v      .+�5x      d� $ ToggleButton��6'   8��  #��z��6n   $��2��5y   '   |�.  $ Press=�6I   #��z��5z   '   #��z��6S   #��z��5{   '   #��z��5|   '   #��z��6_   #��z��5}   '   #��z��6G   #��z��6i   #��z��6�    5y   [   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+5}   �   �� 5~      $ ContentSite��6+     .  #��z! 6Y   #��z" 5   +   #��z��6h   $��3,3,23,3q�6�   #��z��5�   +   #��z��6c   #��z��6�   #��z��6�   5�      �� 5�      $# PART_EditableTextBox��6"   #$ �  6@   8�� $��3,3,23,3q�5�   "   |�. 
������ #��z��6^   $y�Hidden=�6�   #& z% 5�   "   #��z��5�   "   #��z��6Z   #��z��5�   "   #��z��6H   #��z��6p   #��z��6�   .��6�   5�      � 5�      $' Popup��6    $��Bottom=�6/   #��z( 6B   ) . * . |�.  $��Slide=�6�   .��5�      � $+ DropDown��6#   ) . #��z, 6P   #��z- 6y   .+�5�   "   �� $ DropDownBorder��6)   $��0,0,8,8q�6A   #���  6R   #���  6�   $��1,1,1,1q�6�   ) . |�.  . 5�   &     5�   *   $	/ 0.5Q�6;   $0 4Q�6I   #1 �  6Y   $2 4Q�6�   ._�5�   &   �� ) . .��5�   *   �� 3 . $4 	Contained=�6H   5�   '   5�   #   5�      5�      5�      5 5�      P� 5�      6 �@��HasItems7 .  . �5�      �� $8 DropDownBorder��6%    � ��$ 95��6V   5�      P� 5�      6 �@��
IsGrouping7 . . �5�      ��  � �� .  6N   5�      P� 5�      $9 Popup��6"   6 �@�AllowsTransparency7 . . �5�      �� $8 DropDownBorder��6%    �@��CornerRadius$ 0��6Y   �� 5�      $8 DropDownBorder��6%    � ��$ 0,2,0,0q�6S   5�      5�      5�      5�      �� 5�      " ��6"   .�5�   
   ��  � ��$	 1,0q�6,   �� 5�   
    � ��# �  6(   �� 5�   
    � �� �#FFFFFF6'   �� 5�   
    � ��$ 4,0,0,0q�6$   �� 5�   
    � ��$ Stretch=�67   �� 5�   
    � ��$ Center=�65   �� 5�   
    � ��$ 22��6&   �� 5�   
    � ��$ 0��6%   �� 5�   
    � ��# �  6'   �� 5�   
    � ��# �  6'   �� 5�   
    � ��# � 	 6%   �� 5�   
    � �� 5�      �� 5�      "  ��6"   .R�5�      �  5�        5�      CommonStates��	 5�   "     5�   &   $
 0:0:0.3D�67    5�   *     5�   .   $ EaseOut=�69   5�   '   . 5�   "     
Normal��6.     5�   "   	MouseOver��. 5�   &   �� .��5�   *   T� $ 
Visibility�6H   $ HighlightVisual��6o   ..�5�   .   i� $ 0:0:0��6E   # Z 6U   5�   +   W� 5�   *   $ 0D�6:   $ 1X�6G   $ (UIElement.Opacity)�6N   $ HighlightVisual��6~   5�   '   5�   #     5�   "   Disabled��. 5�   &   �� .��5�   *   U� $ Opacity�6H   $ NormalContent��6l   .\�5�   .   n� $: 0:0:0��6E   $	; 0.3Q�6U   5�   +   U� 5�   *   $ Opacity�6H   $ SelectedContent��6l   .\�5�   .   n� $: 0:0:0��6E   $	; 0.3Q�6U   5�   +   5�   '   5�   #   5�        5�      SelectionStates��. 5�   "     
Unselected��6.     5�   "   Selected��. 5�   &   �� .��5�   *   W� $ 0D�6:   $ 1X�6G   $ (UIElement.Opacity)�6N   $ SelectedVisual��6~   U� 5�   *   $ Opacity�6H   $ NormalContent��6l   .\�5�   .   n� $: 0:0:0��6E   $; 0Q�6U   5�   +   U� 5�   *   $ Opacity�6H   $ SelectedContent��6l   .\�5�   .   n� $: 0:0:0��6E   $; 1Q�6U   5�   +   5�   '   5�   #   5�      .+�5�      �� $ NormalVisual��6!   #��z��67   �� 5�      $ HighlightVisual��6!   #���  6:   #���  6e   $��1q�6�   $ 0Q�6�   �� 5�      $ SelectedVisual��6!   #���  69   #���  6u   $��1q�6�   $ 0Q�6�   �� 5�      $< ContentControl��6)   #���  6A   .��5�      �� $ SelectedContent��6/   #��z��6H   #��z��6�   #��z��6�   5�      �� 5�      $ NormalContent��6+   #��z��6B   #��z��6�   #��z��6�   5�      5�      5�      5�      �� 5�      " ��6   8=   6#   �� 5�      " ��6   8=   6&   5     
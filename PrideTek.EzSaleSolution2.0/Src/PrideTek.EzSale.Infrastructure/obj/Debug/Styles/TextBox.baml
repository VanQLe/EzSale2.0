   M S B A M L   `   `   `  ����Y  UPrideTek.EzSale.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:PrideTek.EzSale.Infrastructure.Styles%PrideTek.EzSale.Infrastructure.Styles  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      c6clr-namespace:PrideTek.EzSale.Infrastructure.Behaviors(PrideTek.EzSale.Infrastructure.Behaviors  5      N JPrideTek.Shell.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:PrideTek.Shell.Core;assembly=PrideTek.Shell.CorePrideTek.Shell.Core 5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   TBInputStyle  �� 
TargetType  ControlBaseStyle �� BasedOn �� Property �� Value  ControlBackground  ControlBorderBrush  ControlFamilyFont  ControlFontSize  ControlForeground  InputTBStyle �� 
TargetType �� Triggers P� Property P� Value  DisabledForeground �Name'   !System.Windows.VisualStateManager	    VisualStateGroups%  System.Windows.VisualStateGroup
   Transitions%  System.Windows.VisualTransition   GeneratedDuration   GeneratedEasingFunction/  )System.Windows.Media.Animation.CircleEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty	 W� To g� Duration 	 DisabledOpacity ��Name �� CornerRadius J� Opacity ��Name 
 TextBoxInputStyle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      =local3clr-namespace:PrideTek.EzSale.Infrastructure.Styles  5      .sys&clr-namespace:System;assembly=mscorlib  5      D	behaviors6clr-namespace:PrideTek.EzSale.Infrastructure.Behaviors  5      M
converters>clr-namespace:PrideTek.Shell.Core;assembly=PrideTek.Shell.Core  5      %�  &	        7  &	 �    7   &	
 �    7  �� 5
      "  ��6!   8   .�5   
   ��  �@J�SnapsToDevicePixels . 60   �� 5   
    � ��$ Stretch=�67   �� 5   
    � ��$ Center=�65   �� 5   
    � ��$ Stretch=�60   �� 5   
    � ��$ Stretch=�6.   �� 5   
    � ��$	 2,1q�6$   �� 5   
    � ��$ 1q�6,   �� 5   
    �@��TextWrapping$ NoWrap=�6)   �� 5   
    � ��# �  6'   �� 5   
    � ��# �  6(   �� 5   
    � ��# �  6'   �� 5   
    � ��# �  6%   �� 5   
    � ��# �  6'   �� 5   
    �@��SelectionBrush# �  6+   �� 5   
    �@��
CaretBrush
 �   �6'   �� 5   
    � ��$ 35��6#   �� 5   
    � ��$	 350��6"   5      �� 5      "  ��6!   8   .�5    
   ��  � �� 5!      �� 5"      " ��6"    5#      P� 5$       � {� .  . �5%      �� # �  6;    � ��5&      .R�5)      � $ RootElement��6   	 5*        5+      CommonStates��
 5,   "     5-   &   $ 0:0:0:3D�67    5.   *     5/   .   $ EaseOut=�69   51   '   . 53   "     
Normal��6.     54   "   	MouseOver��. 55   &   �� .��56   *   W� $ 
BorderOver��6:   $ Opacity�6]   $ 1X�6�   $ 0D�6�   57   '   58   #     59   "   Disabled��. 5:   &   �� .��5;   *   W� $ 0D�6:   $ Border��6H   $ Opacity�6g   # � 	 6�   W� 5<   *   $ 0D�6:   $ PART_ContentHost��6H   $ Opacity�6q   # � 	 6�   5=   '   5>   #     5?   "   ReadOnly��. 5@   &   �� .��5A   *   W� $ 0D�6:   $ Border��6H   $ Opacity�6g   # � 	 6�   5B   '   5C   #   5D        5F      FocusStates��
 5G   "     5H   &   $ 0:0:0.3D�67    5I   *     5J   .   $ EaseOut=�69   5L   '   . 5N   "     Focused��. 5O   &   �� .��5P   *   W� $ (UIElement.Opacity)�6:   $ FocusedVisual��6j   $ 1X�6�   $ 0D�6�   5Q   '   5R   #     5S   "   	Unfocused��6.   5T        5V      ValidateStates��. 5W   "     	Valid��6.     5X   "   InvalidUnfocus��. 5Y   &   �� .��5Z   *   W� $ ValidationErrorElement��6:   $  (FrameworkElement.Opacity)�6i   $ 1X�6�   $ 0D�6�   5[   '   5\   #     5]   "   InvalidFocused��. 5^   &   �� .��5_   *   W� $ FocusedVisual��6;   $  (FrameworkElement.Opacity)�6a   $ 0X�6�   $ 0D�6�   W� 5`   *   $ ValidationErrorElement��6;   $  (FrameworkElement.Opacity)�6j   $ 1X�6�   $ 0D�6�   5d   '   5e   #   5f      .+�5h      �� $ Border��6!   $ 3��61   #��z��6B   ���#CCCCCC#��z��6�   �� 5i      $ 
BorderOver��6!   $ 3��65   #��z��6F   $ 0Q�6z   ���#CCCCCC6�   �� 5j      $ FocusedVisual��6!   $ 3��68   $ 0Q�6I   ���#CCCCCC#��z��6k   �� 5k      $ ValidationErrorElement��6!   $ 3��6A   ���#CCCCCC$��1q�6h   $ 0Q�6|   5p      �� 5r      $ PART_ContentHost��62   $��0q�6'   #��z��6L   #��z��6�   5s      5v      5z      5|      �� 5�      "  ��6&   8   .�5�   
   ��  � ��# �  6'   �� 5�   
    � ��# �  6(   �� 5�   
    � ��# �  6'   �� 5�   
    � ��$ Center=�6.   5�      5�      
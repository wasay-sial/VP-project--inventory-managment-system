   M S B A M L   `   `   `  ����?  ;VP 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VP_2VP_2  5   	       VP_2.Menu_user   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:VP_2     5   	     � Title$  	User Menu��5   	   $	��450��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5         PrimaryColor �� Color  SecondaryColor  AccentColor  
HoverColor  ButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius	   	Direction
   ShadowDepth �� 
TargetType �� CornerRadius �� Padding �� Triggers P� Property P� Value  TitleTextStyle��%�  &	        &	 !     &	 B     &	 c     &	 �     7   7  '� ;    7  &	     �� 5   
   $ #6F4F1F��6/   �� 5   
   $ #8B5E3C��61   �� 5   
   $ #D2B48C��6.   �� 5   
   $ #C8A57A��6-   �� 5   
   " ��6$   .�5      ��  � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$	 250��6&   �� 5       � ��$ 60��6'   �� 5       � ��$ 10q�6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 ���� 6,   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ 16(�6)   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5        � ��$
 10,5q�6(   �� 5!       �@J�Effect 5"        5#      $ Black��6'   $ 10Q�65   $		 270Q�6E   $
 3Q�6U   5%      �� 5&       � �� 5'      �� 5(      " ��6&   .R�5)      �� #��z��6!   #��z��5*   !   $��1q�5+   !   $ 15��5,   !   # z��5-   !   ._�5.      �� $��Center=�6/   $��Center=�5/   /   50      51      53       55      P� 56       �@J�IsMouseOver . . �57      ��  � ��8  63   58      5:      �� 5=   
   " �6   .�5>      ��  � ��8   6+   5?      �� 5B   
   " ��6   .�5C      ��  � ��
 �����6+   �� 5D       � ��$ 36(�6)   �� 5E       � ��$
 Bold"�6+   �� 5F       � ��$
 Left=�64   �� 5G       � ��$ Center=�62   �� 5H       � ��$ 79,0,0,0q�6'   5I      5J      .��5L      �  � RowDefinitions 5N   
   �� 5O      $
��Auto �6   �� 5P      $��* �6   .+�5T   
   �� #��[  6   $ 20q�6<   $��Stretch=�6I   ._�5U      �� $��	User Menu��6   #��[ 6)   5V      � 5Y   
   $��1��6   .+�5[       � -   5          �Name$ ContentFrame��5[        � NavigationUIVisibility$ Hidden=�6*   5\      �� 5_   
    �� Orientation$ Vertical=�6   $��Right=�6,   $	��Top=�6H   $��10q�6`   .+�5`      �� -   5         ��Name$ ShowUserButton��5`      $��	Show User��6-   #��[ 6A   6f   �� 5a      -   5        $ PlaceOrderButton��5a      $��Place Order��6/   #��[ 6E   6j   �� 5b      -   5        $ 
ExitButton��5b      $
��Exit��6)   #��[ 68   6]   5c      5d      5e      
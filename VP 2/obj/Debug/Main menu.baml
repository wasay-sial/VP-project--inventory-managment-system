   M S B A M L   `   `   `  ����?  ;VP 2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VP_2VP_2  5   	       VP_2.Main_menu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:VP_2     5   	     � Title$  	Main Menu��5   	   $	��600��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5         PrimaryColor �� Color  SecondaryColor  AccentColor  
HoverColor  ButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius	   	Direction
   ShadowDepth �� 
TargetType �� CornerRadius �� Padding J� Opacity T� Y J� Effect-  'System.Windows.Media.Effects.BlurEffect   Radius �� Triggers P� Property P� Value  TitleTextStyle��%�  &	        &	 !     &	 B     &	 c     &	 �     7   7  '�     &	 b    �� 5   
   $ #6F4F1F��6/   �� 5   
   $ #8B5E3C��61   �� 5   
   $ #D2B48C��6.   �� 5   
   $ #C8A57A��6-   �� 5   
   " ��6$   .�5      ��  � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$	 200��6&   �� 5       � ��$ 60��6'   �� 5       � ��$ 10q�6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 ���� 6,   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ 16(�6)   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$
 10,5q�6(   �� 5        �@J�Effect 5!        5"      $ Black��6'   $ 10Q�65   $		 270Q�6E   $
 3Q�6U   5$      �� 5%       � �� 5&      �� 5'      " ��6&   .R�5(      � .+�5)      �� #��z��6%   #��z��5*   %   $��1q�5+   %   $ 15��5,   %   # z��5-   %   ._�5.   "   �� $��Center=�63   $��Center=�5/   3   50      �� 52      
�������
������ $��0q�6R   $��Bottom=�53   %   $��Stretch=�6@   $	 0.3Q�6^   z�54   "   T� 55   &   $ 10Q�69    57   "     58   &   $ 5Q�61   5:      5;      5<      5>       5?      P� 5@       �@J�IsMouseOver . . �5A      ��  � ��8  63   5B      5D      �� 5G   
   " �6   .�5H      ��  � ��
 ���� 6+   5I      �� 5L   
   " ��6   .�5M      ��  � ��
 �����6+   �� 5N       � ��$ 36(�6)   �� 5O       � ��$
 Bold"�6+   �� 5P       � ��$ Center=�64   �� 5Q       � ��$ Center=�62   5R      5S      .��5U      � ��5V   
   �� 5X       �� ImageSource$A ;C:\Users\Abdul Wasay Sial\Desktop\Vp project\VP 2\store.jpg��6    �� RelativeTransform 5Y      �� 5Z       �� Angle$ 0Q�6&    �� CenterX$	 0.5Q�60    �� CenterY$	 0.5Q�6>   5]       � RowDefinitions 5_   
   �� 5`      $
��Auto �6   �� 5a      $��* �6   �� 5b      $
��Auto �6   .+�5f   
   �� #��[  6   $ 20q�6<   $��Stretch=�6I   ._�5g      �� $��	Dashboard��6   #��[ 6)   5h      � 5k   
   $��1��6    5l        5m      .+�5p      ��  �� Orientation$ Vertical=�6   $��Center=�60   $��Center=�6M   .+�5r      �� $ 
Horizontal=�6   $��Center=�66   .+�5s      �� -   5         ��Name$ ShowProductsButton��5s      $��Show Products��69   #��[ 6Q   6v   �� 5t      -   5        $ ShowUsersButton��5t      $��
Show Users��66   #��[ 6K   6p   5u      �� 5x      $ 
Horizontal=�6   $��Center=�66   .+�5y      �� -   5        $ ShowCategoriesButton��5y      $��Show Categories��6;   #��[ 6U   6z   �� 5z      -   5        $ ShowOrdersButton��5z      $��Show Orders��67   #��[ 6M   6r   5{      �� 5~      $ 
Horizontal=�6   $��Center=�66   .+�5      �� -   5        $ ShowSuppliersButton��5      $��Manage Suppliers��6:   #��[ 6U   6z   �� 5�      -   5        $ ShowPurchaseOrdersButton��5�      $��Purchase Orders��6?   #��[ 6Y   6~   5�      5�      5�      � 5�   
   $��2��6   .+�5�      �� -   5        $ 
ExitButton��5�      $
��Exit��6)   #��[ 68   $	��200��6]   $��Center=�5�      $��10q�62   5�      5�      5�      
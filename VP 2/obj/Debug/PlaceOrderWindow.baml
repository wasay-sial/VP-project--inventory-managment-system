   M S B A M L   `   `   `  ����  VP 2    VP_2.PlaceOrderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Place Order��5   	   $	��600��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5
         PrimaryColor �� Color  SecondaryColor  AccentColor  ButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius	   	Direction
   ShadowDepth �� 
TargetType �� CornerRadius �� Padding��%6  &	        &	 !     &	 B     &	 c     7   '� �    7  �� 5   
   $ #6F4F1F��6/   �� 5   
   $ #8B5E3C��61   �� 5   
   $ #D2B48C��6.   �� 5   
   " ��6$   .�5      ��  � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$	 150��6&   �� 5       � ��$ 50��6'   �� 5       � ��$ 10q�6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 ���� 6,   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ 14(�6)   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$
 10,5q�6(   �� 5       �@J�Effect 5        5       $ Black��6'   $ 10Q�65   $		 270Q�6E   $
 3Q�6U   5"      �� 5#       � �� 5$      �� 5%      " ��6&   .R�5&      �� #��z��6!   #��z��5'   !   $��1q�5(   !   $ 15��5)   !   # z��5*   !   ._�5+      �� $��Center=�6/   $��Center=�5,   /   5-      5.      50      51      �� 54   
   " �6   .�55      ��  � ��8   6+   56      57      .��59      �  � RowDefinitions 5;   
   �� 5<      $
��Auto �6   �� 5=      $��* �6   .+�5A   
   �� #��[  6   $ 20q�6<   $��Stretch=�6I   ._�5B      �� $��Place Your Order��6   
�������$��36(�6C   $
��Bold"�6Q   $��Center=�6c   $��Center=�6�   5C      � 5F   
   $��1��6   $��20q�6    � ColumnDefinitions 5G      �� 5H      $
��199* �6#   �� 5I      $
��181* �6#   .+�5M      �� $��0��6   $��10,10,10,10q�6)   .+�5N      �� $��Available Products��6   $��20(�66   $
��Bold"�6D   $��0,0,0,10q�6V   &   System.Windows.Controls.DataGrid  5O      -   5          Name$ ProductDataGrid��5O         AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�6b   $	��300��6y   $	��374��6�      Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	ProductId+6W     5R      $
 Name��6-   $	 150 6[    6;   �� *ProductName+6[     5S      $ Quantity��6-   $	 100 6\    6?   �� *
Quantity+6\     5T      $ Price��6-   $	 100 6V    6<   �� *Price+6V     5U      $ Category ID��6-   $	 100 6a    6B   �� *
CategoryId+6a   5W      5X      �� 5[      $��1��6   $��	20,0,0,20q�6)   .+�5\      �� $��Order Details��6   $��20(�61   $
��Bold"�6?   $��0,0,0,10q�6Q   �� 5_       �� Orientation$ 
Horizontal=�6   $	��0,5q�66   .+�5`      �� $��	Order ID:��6    $	��100��61   $��Center=�6=   �� 5a      -   5         ��Name$ OrderIdTextBox��5a      $	��200��66   5b      �� 5d      $ 
Horizontal=�6   $	��0,5q�66   .+�5e      �� $��Product ID:��6    $	��100��63   $��Center=�6?   �� 5f      -   5        $ ProductIdTextBox��5f      $	��200��68   5g      �� 5i      $ 
Horizontal=�6   $	��0,5q�66   .+�5j      �� $��Product Name:��6    $	��100��65   $��Center=�6A   �� 5k      -   5        $ ProductNameTextBox��5k      $	��200��6:   5l      �� 5n      $ 
Horizontal=�6   $	��0,5q�66   .+�5o      �� $��Address:��6    $	��100��60   $��Center=�6<   �� 5p      -   5        $ AddressTextBox��5p      $	��200��66   5q      �� 5s      $ 
Horizontal=�6   $	��0,5q�66   .+�5t      �� $��Email:��6    $	��100��6.   $��Center=�6:   �� 5u      -   5        $ EmailTextBox��5u      $	��200��64   5v      �� 5x      -   5         ��Name$ SubmitOrderButton��5x      $��Submit Order��64   #��[ 6K   6p   �� 5y      -   5        $ CancelButton��5y      $��Cancel��6/   #��[ 6@   6e   5z      5{      5|      5}      
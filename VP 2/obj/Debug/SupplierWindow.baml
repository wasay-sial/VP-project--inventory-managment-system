   M S B A M L   `   `   `  ����  VP 2    VP_2.SupplierWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Supplier Management��5   	   $	��500��6%   $	��800��62    � 	Resources 5         	DarkBrown �� Color  MediumBrown  
LightBrown  
LightBeige  ButtonBackground  ButtonForeground��%  &	        &	 !     &	 B     &	 c     &	 �     &	 �     �� 5   
   $ #3E2A47��6,   �� 5   
   $ #8B5C42��6.   �� 5	   
   $ #D2B48C��6-   �� 5
   
   $ #F5F5DC��6-   �� 5   
   $ #8B4513��63   �� 5   
   $ #FFF5EE��63   5      .��5      � $��10q�6   #��[ 6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Supplier Management��6   $��20(�6/   $
��Bold"�6=   $��10q�6O   $��0��6[   #��[  6h   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ SuppliersDataGrid��5         AutoGenerateColumns .  $��1��6J   $��10q�6W   #��[ 6c   #��[ 6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Supplier ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6Y   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6:   �� *
SupplierId+6e     5      $ Supplier Name��6%   $	 200 6]   
 6<   �� *SupplierName+6]     5      $ Contact��6%   $	 200 6R   
 66   �� *	Contact+6R   5       �� 5#   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��10q�6W   .+�5$      �� -   5        $��Add Supplier��5$      $	��120��6,   $��5q�68   #��[ 6C   #��[ 6r   6�   �� 5%      -   5        $��Edit Supplier��5%      $	��120��6-   $��5q�69   #��[ 6D   #��[ 6s   6�   �� 5&      -   5        $��Delete Supplier��5&      $	��120��6/   $��5q�6;   #��[ 6F   #��[ 6u   6�   5'      5(      5)      
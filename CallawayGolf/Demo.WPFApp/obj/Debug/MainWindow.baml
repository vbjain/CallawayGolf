   M S B A M L   `   `   `  ����F  BDemo.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:Demo.Common;assembly=Demo.CommonDemo.Common  5   	   F BDemo.WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Demo.WPFApp.ClassesDemo.WPFApp.Classes 5   	   )clr-namespace:Demo.WPFAppDemo.WPFApp 5   	      Demo.WPFApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Acommon.clr-namespace:Demo.Common;assembly=Demo.Common     5   	   5classes!clr-namespace:Demo.WPFApp.Classes     5   	   +localclr-namespace:Demo.WPFApp     5   	     � WindowState$  	Maximized=�61    � WindowStyle$ SingleBorderWindow=�6I    � WindowStartupLocation$ CenterScreen=�6j    � 	Resources 5	      -  'Demo.WPFApp.Classes.LeftHandedConverter   LeftHandedConverter.  (Demo.WPFApp.Classes.GenderColorConverter  GenderColorConverter2  ,Demo.WPFApp.Classes.InventoryItalicConverter  InventoryItalicConverter��%W   &	        &	      &	 &       5
   
   6D     5   
   6F     5   
   6N   5      .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 0,1&�63   ��5      �  � Color$ Maroon��6#    � Offset$	 0.0Q�62   6A   � 5      $ Crimson��6#   $	 0.4Q�63   6B   � 5      $ 
LightCoral��6#   $	 0.7Q�66   6E   5       � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��* �6   6)   .+�5   
   � $��0��6   .+�5       �� -   5        $��	btnUpload��5       $��Upload Json��6&   $��5q�6T   $��5q�6`   $��40��6k   6y   �� 5!      -   5        $��btnUploadExtra��5!      $$��Upload Json With Extra Service��6+   $��5q�6q   $��5q�6}   $��40��6�   6�   5"      � 5$   
   $��1��6    5%      �� 5&      $	��150 �6    6/   �� 5'      $��* �6    6-   .+�5*      �� $��0��6   .��5+      �� ��5,      �� 	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType  Demo.WPFApp.MainWindow"
   �� Path$ 
Categories���5/      �� 50      .R�51      ��  �� Orientation$ 
Horizontal=�6)   52      ��54      �� 55      .R�56      �� $ Vertical=�6)   $	��100��6@   $	��125��6L   
�������$��5q�6k   .+�57   "   �� -   5        $	��100��57   (   $	��100��65   ��58   ,   �� $ ImageUrl�
 � Tag 59   J   �� $
 Name�6f   �� 5:   "   -   5        $��20��5:   ,   $	��100��68   
����  ���5;   ,   �� $
 Name� 5<   K   �� $
 Name�6g   5=      5>      5@      5A      �� 5B      $��1��6   .��5C      �� ��5D      �� 	 �� *FindAncestor+"
  $ 
Categories���5G      �� 5H      .R�5I      �� $ Vertical=�6)   6B   5J      ��5L      �� 5M      .R�5N      �� ��6+   �� $ Models� 6P   �� $
 Name���5O   "   �� 5P   &   .R�5Q   *   �� $ Vertical=�65   $��5q�6L   6Y   5R   '   ��5T   "   �� 5U   &   .R�5V   *   �� ��67   �� $ Products���5W   .   �� 5X   2   .R�5Y   6   �� $��10q�6?   ��6K   �� $
 Name���5Z   :   �� 5[   >   $	 0,0&�6R   $	 0,1&�6c   ��5]   F   � $
 Gray��6S   $	 0.0Q�6`   6o   � 5^   F   $ 	LightGray��6S   $	 0.4Q�6e   6t   � 5_   F   $ 	Gainsboro��6S   $	 0.7Q�6e   6t   5a   ?   ��5c   :   �� 5d   >   .R�5e   B   �� $��16(�6]   
���  ��$
��Bold"�6   ��6L   �� 6�   5f   ?   .��5h   :   �� 6K   5i   7   5j   3   ��5l   .   �� 5m   2   .R�5n   6   �  � ColumnDefinitions 5o   :   �� 5p   >   $	��470 �6O   6]   �� 5q   >   $��30 �6O   6\   .+�5s   :   �� $��16(�6f   $��0��5t   D    �� Padding$ 5q�6T   ��5s   D   �� $ Description���5u   D   �� $
 Hand� �� 	Converter# [  ��5v   D   �� $ Gender�# [ 5w   G   �� 5x   :   $��16(�6d   $��1��5y   H   $ 5q�6X   ��5x   D   �� $ 	Inventory���5z   D   �� $ 	Inventory�# [ 6�   5{   7   5|   3   5~   +   5   '   5�      5�      5�      5�      5�      5�      5�      
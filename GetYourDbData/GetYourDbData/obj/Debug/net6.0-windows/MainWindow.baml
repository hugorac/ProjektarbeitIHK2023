   M S B A M L   `   `   `  ����  GetYourDbData    GetYourDbData.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5        $	��500��5   !   $
��1000��6.     � Title  6	   �� *Title+ � 	Resources 5       �� Color   blueColorBrush  inputBackgroundColorBrush  textBoxBackgroundColorBrush  textFontFamily �� 
TargetType �� Property �� Value��%f  &	        &	 &     &	 O     &	 u     '�� �     7   7  '��     7   7   7  7  '��     7  7   7  7   �� 5   
   $ #007ACC��6   6*   �� 5   
   $ 
DarkOrange��6   6-   �� 5   
   $ #F5F5F5��6   6*   *�5	   
   	Arial)�5      �� 5   
   " ��6   .�5      ��  � ��8   6+   �� 5       � ��8  6+   �� 5       � ��$ 18(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$	 0 3q�6'   �� 5       � ��8   6+   �� 5       � ��8  6,   �� 5       � ��8  6+   �� 5       � ��8  6+   �� 5       � ��$ 14(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$	 0 3q�6'   �� 5       � ��8   6+   �� 5       � ��8  6,   �� 5       � ��8  6+   �� 5       � ��8  6+   �� 5       � ��$ 14(�6)   5       5"      .��5#      �  � ColumnDefinitions 5$   
   �� 5%      �� 5&      .+�5+   
   � #��[ 6   .+�5,      ��  �� Orientation$ Vertical=�6   $��10q�60   .+�5-      �� $��GetYourDbData��6   $��36(�61   �� 5/      $��Database Name:��6   �� 50      -   5         ��Name$ dbNameTextBox��50      $��30��6O   $��1q�51      ��50   1   �� *DatabaseName+51      �� 53      $��Table Names:��6   �� 54      -   5        $ tableNameTextBox��54      $��30��6�   $��1q�55      ��54   4   �� *	TableName+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�.��55   .    J� InputBindings 56      �� 57      
 �� Key$ Enter��6p    �� Command 6%   �� *FillTableNamesListCommand+ �� CommandParameter 6S   �� 6p   .��58   -   59      �� 5:      -   5         ��Name$ tableNameListBox��5:   U   $	��100��6o   $��1q�6|   $��14(�5;       �� SelectedItem 5:      �� *SelectedTable+$	 OneWayToSource=���5<      �� *
TableNames+ 5=      �� 5>      $ Delete��6s    6%   �� *DeleteTableNamesEntryCommand+ 6V   �� 6s   5@      �� 5A      $��GET DB��6   $��30��6*   ��66   �� *GetDataCommand+��6Y   �� 5B      5C      � 5D   
   $��1��6   .+�5E      �  � RowDefinitions 5F      �� 5G      $��* �6$   �� 5H      $
��auto �6$   .+�5J      �� .��5K      �� -   5        $ 	sqlOutput��5K   2   $��0q�6   $��consolas)�6`   $��10(�6v   $��10q�6�   
���   �$
��True��6�   ��6E   �� *	SqlResult+6�   5L      �� 5M      $��1��6   .+�5N      �� -   5        $"��Copy SQL-Script to Clipboard��5N      6D   �� 5O      -   5        $��Save SQL-Script as file��5O      6?   5P      5Q      5R      5S      5T      
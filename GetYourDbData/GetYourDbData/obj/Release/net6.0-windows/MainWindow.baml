   M S B A M L   `   `   `  ����   GetYourDbData    GetYourDbData.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Get Your Db Data��$	��500��$
��1000��.��� ���#F5F5F5 � RowDefinitions �� $
��Auto ��� $��* �.+��� $��GetYourDbData�����#007ACC$��36(�$
��Bold"�$��	0,20,0,10q�$��Center=�$��Arial)��� $��1�� �� Orientation$ Vertical=�$��Center=�$	��Top=�$��0,18,0,0q�.+��� $��10q�.+��� $��Database Name:�����#007ACC$��18(�$��Arial)��� -    ��Name$ dbNameTextBox��$	��250��$��30��$
��Left=����#007ACC$��1q�
����������#007ACC$��14(�$��5q��� $��10q�.+��� $��Table Names:�����#007ACC$��18(�$��Arial)��� -   $ tableNameTextBox��$	��250��$��30��$
��Left=����#007ACC$��1q�
����������#007ACC$��14(�$��5q��� -    ��Name$ tableNameListBox��$	��250��$	��100�����#007ACC$��1q�
����������#007ACC$��14(�$y�	Collapsed=�$��5q�$��0,5,0,0q����� *EnteredTableNames+�� $��GET OPEN DB��$	��135��$��30�����#007ACC
�������$��16(�$
��Bold"��� -   $ 
LogTextBox�����#F5F5F5$
��Left=�$��
28,229,0,0q�$��1�� �� TextWrapping$
 Wrap=�$	��Top=�$	��242��$	��139��
��������� -   ���#007ACC
�������$��16(�$
��Bold"�$
��Copy��$��62��$��30��$
��Left=�$	��Top=�$��800,121,0,0q�$��1���� ���#007ACC$��14(�$��Arial)�$
��Left=�$��
751,87,0,0q�$��1��$
��Wrap=�$)��#Copy Connection String to Clipboard��$	��Top=�$	��160��$��34�� �� TextAlignment$ Center=�
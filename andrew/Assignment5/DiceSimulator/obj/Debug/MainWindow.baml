   M S B A M L   `   `   `  ����H  DDiceSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DiceSimulatorDiceSimulator  5   	       DiceSimulator.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:DiceSimulator     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $
��Fill=�6@   $��10q�6O   ��6$   �� *
FirstDie+6O   �� 5      $��1��6   $
��Fill=�6A   $��10q�6P   ��6$   �� *	SecondDie+6P   5      �� 5   
   -   5        $��BtnRoll��5      $��1��6    $
��Roll��6-   $��Center=�6R   $��Center=�6v   $��28(�6�   $��50 10 50 10q�6�   5      5      
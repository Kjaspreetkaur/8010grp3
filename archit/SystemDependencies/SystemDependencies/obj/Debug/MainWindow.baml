   M S B A M L   `   `   `  ����M  ISystemDependencies, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SystemDependenciesSystemDependencies  5   	   #    SystemDependencies.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5	   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5
   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SystemDependencies     5   	     � Title$  System Dependencies��5   	   $	��350��6%   $	��625��62   .��5      � ���#000000 � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��9* �6   .+�5   
   � $��0��6   $��5q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��5* �6#   �� 5      $��2* �6#   �� 5      $��* �6#   �� 5      $��2* �6#   .+�5      �� $��0��6   $��Comm:��6$   $��Center=�64   $��14(�6O   $��Center=�5      ���#ffffff65   �� 5      -   5        $	��tbx��5   &   $��1��6   
������ 
������ ���#ffffff$��16(�5    3   $��Center=�6A    �� 
CaretBrush �#ffffff��5   1   �� *	Command+5    x   �� 5!      $��2��6    �� CornerRadius$ 5,5,5,5��6%   ���#E64C65._�5"      �� -   5        $��
btnExecute��5"      $��Execute��6+   $��
Constantia)�6V   $��16(�5#      
������ ���#ffffff
������ 6Y   5$      �� 5%      $��3��6   $
��-OR-��6$   $��Center=�63   $��14(�6N   $��Center=�5&      ���#ffffff65   �� 5'      $��4��6   $ 5,5,5,5��6%   ���#E64C65._�5(      �� -   5        $��btnSimulate��5(      $��Load Example��6,   $��
Constantia)�6]   $��16(�5)      
������ ���#ffffff
������ 6Y   5*      5+      � 5,   
   $��1��6    5-      �� 5.      $��* �6#   �� 5/      $��* �6#   .+�51      �� $��0��6   .��52      �� -   5        $��	tblInputs��52   1    �� TextAlignment$
 Left=�6   $��10q�6B   ���#000000���#FFFFFF$��14(�53      ��6*   �� *Inputs+54      �� 55      $��1��6   .��56      �� -   5        $��
tblOutputs��56   1   $
 Left=�6   $��10q�6C   ���#000000���#FFFFFF$��14(�57      ��6*   �� *	Outputs+58      59      5:      5;      
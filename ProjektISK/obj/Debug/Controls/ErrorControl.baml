   M S B A M L   `   `   `  ����E  AProjektISK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ProjektISK.ControlsProjektISK.Controls  5      =#clr-namespace:ProjektISK.ConvertersProjektISK.Converters  5      &     ProjektISK.Controls.ErrorControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ProjektISK.Controls     5      :
converters#clr-namespace:ProjektISK.Converters     5      U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5      .��5      � $��0 5 0 0q�6     � 	Resources  5   
   0   *ProjektISK.Converters.EnumBooleanConverter   enumBooleanConverter��%   &	          5      6.   5       � RowDefinitions 5   
   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   	� $��Cały pakiet��6    	� 	GroupName$
 type��6,   $��2��6=   	� 5   
   -   5        $��FrameNumberType��5   -   $��Liczba ramek��6   $
 type��6D   $��1��6U   �� 5   
   $��2��6   $��25 3 3 3q�6   {�61   ��  �� ElementName$ FrameNumberType�� �� Path$ 	IsChecked�	� 5   
   -   5        $��Random��5      $��Losowe bity��6$   $��1��6:   $ errorPosition��6J    d� 	IsChecked 5      �� *ErrorPositionType+ �� 	Converter# [   �� ConverterParameter$ Random��	� 5   
   -   5        $��
Neighbours��5      $��1��6(   $��Sąsiadujące bity��65   $��1��6P   $ errorPosition��6`    5       �� *ErrorPositionType+# [  $ 
Neighbours��5!      5"      
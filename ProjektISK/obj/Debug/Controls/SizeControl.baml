   M S B A M L   `   `   `  ����E  AProjektISK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ProjektISK.ControlsProjektISK.Controls  5      =#clr-namespace:ProjektISK.ConvertersProjektISK.Converters  5      %    ProjektISK.Controls.SizeControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ProjektISK.Controls     5      U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      4
converters#clr-namespace:ProjektISK.Converters  5      .��5      � $��0 5 0 0q�6     � 	Resources  5   
   0   *ProjektISK.Converters.EnumBooleanConverter   enumBooleanConverter��%   &	          5      6.   5       � RowDefinitions 5   
   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   	� -   5        $��	FixedSize��5      $��Stała wartość��6'    d� 	IsChecked 5      �� *
SizeType+ �� 	Converter# [   �� ConverterParameter$ 	FixedSize��	� 5   
   -   5        $��
RandomSize��5      $��1��6(   $��Losowa wartość��65    5      �� *
SizeType+# [  $ 
RandomSize���� 5   
   $��1��6i   *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton . {�6   ��  �� ElementName$ 	FixedSize�� �� Path$ 	IsChecked���6N   �� *	FixedSize+	   	Watermark	 5      �� *	Watermark+6I   � 5   
   $��1��6L   $��1��6\   {�6   �� $ 
RandomSize��$ 	IsChecked� 5       �� 5!      $
��0.2* �6#   �� 5"      $
��0.4* �6#   �� 5#      $
��0.2* �6#   �� 5$      $
��0.4* �6#   .+�5'      �� $��3 0 0 0q�6   $��od��6)   �� 5(      $��1��6   ��6&   �� *RandomStart+�� 5)      $��3 0 0 0q�6   $��2��6)   $��do��69   �� 5*      $��3��6   ��6&   �� *	RandomEnd+5+      5,      5-      
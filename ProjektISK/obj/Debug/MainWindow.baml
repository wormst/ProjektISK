   M S B A M L   `   `   `  ����E  AProjektISK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ProjektISK
ProjektISK  5   	   9!clr-namespace:ProjektISK.ControlsProjektISK.Controls  5   	   =#clr-namespace:ProjektISK.ViewModelsProjektISK.ViewModels  5	   	       ProjektISK.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   $localclr-namespace:ProjektISK  5   	   0controls!clr-namespace:ProjektISK.Controls  5   	   4
viewModels#clr-namespace:ProjektISK.ViewModels  5	   	     � Title$  Projekt ISK��5   	   $	��685��6   $	��820��6-   $	��685��6<   $	��820��6I    � WindowStartupLocation$ CenterScreen=�6U   .��5      � $��5q�6    � 	Resources 5   
    �� 
TargetType �� BasedOn �� Property �� Value��%  '��       7��'�� L     7��'�� �     7���� 5      " ��6   8   .�5      ��  � ��$ 3q�6+   5      �� 5      " ��6   8   .�5      ��  � ��$ Center=�66   5      �� 5      " ��6   8   .�5      ��  � ��$ 3q�6+   5      5       � RowDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $
��0.3* �6   �� 5      $
��0.3* �6   �� 5      $
��0.3* �6   �� 5      $
��0.1* �6    � ColumnDefinitions 5!   
   �� 5"      �� 5#      .+�5'   
   �� $��0��6   $��Suma kontrolna ramki��6    .��5(      )   #ProjektISK.Controls.ChecksumControl  	 � DataContext	 6'   �� *FrameChecksumViewModel+5)      �� 5+   
   $��0��6   $��1��6    $��Suma kontrolna pakietu��60   .��5,        	 6'   �� *PacketChecksumViewModel+5-      �� 50   
   $��1��6   $��Rozmiar danych ramki��6    .��51      %   ProjektISK.Controls.SizeControl  	 6#   �� *FrameSizeViewModel+52      �� 54   
   $��1��6   $��1��6    $��Liczba ramek w pakiecie��60   .��55        	 6#   �� *PacketSizeViewModel+56      �� 59   
   $��2��6   $��1��6    $��Typ przekłamania danych��64   .��5:      &    ProjektISK.Controls.ErrorControl  5;      �� 5=   
   $��2��6   $��1��6    $!��Liczba przekłamań w ramce��60   .��5>        
   	Watermark$"
 liczba przekłamań w bitach��6<   	 6#   �� 6<   5?      �� 5B   
   $��3��6   $��2��6    $��Czas działania��64   .��5C      )   #ProjektISK.Controls.DurationControl  	 6'   �� *DurationViewModel+5D      � 5F   
   $��4��6   $��2��6   .+�5G      �� $��Start��6   ��6%   �� *StartCommand+5H      5I      5J      
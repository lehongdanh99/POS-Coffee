   M S B A M L   `   `   `  ����D  @CoffeePos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CoffeePos	CoffeePos  5   	       CoffeePos.Home   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   #localclr-namespace:CoffeePos  5   	     � Title$
  Home��5	   	   $	��600��6   $
��1080��6#    � WindowStartupLocation$ CenterScreen=�60    � WindowStyle$
 None=�6U   
������� � 	Resources 5
         MenuOpen �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	MenuClose��%�  &	        &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $ 60Q�63     5      $ 0:0:0.2��6'   $	 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $	 200Q�63     5      $ 0:0:0.2��6'   $ 60Q�69   5      5      5       � Triggers 5      :� 5   
   	 :� RoutedEvent$	 ButtonBase.Click��6   
 :� 
SourceName$
 ButtonOpenMenu��66   .[�5      �� #��[  6   6G   5      :� 5   
   $	 ButtonBase.Click��6   $
 ButtonCloseMenu��66   .[�5      �� #��[ 6   6H   5      .��5"      � .+�5#   
   � $��70��6   $	��Top=�6   ���	#FFC7AD00.+�5$      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5)      �� -   5        $��Right=�5)      $��Center=�65   $��
Gọi Món��6P   $��10q�6b   6�   �� 5*      -   5        $��Right=�5*      $��Center=�65   $��Đăng ký thành viên��6P   $��10q�6m   6�   5+      5-      � 5.   
   -   5         �Name$ GridMenu��5.      $��60��6!   $
��Left=�6,   ���	#FF7F5D00.+�5/      �� .+�50      � $	��150��6   
�������.+�51      �� -   5         ��Name$ ButtonCloseMenu��51      $	��Top=�52      $��60��65   $��60��6@   $��Right=�54      $y�	Collapsed=�69   ��53      Z� ��63   Z� .��56      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowLeft=�62   ���	#FF7F5D00$��25��57   2   $��25��58   2   6@   59      �� 5:      -   5        $ ButtonOpenMenu��5:      $	��Top=�5;      $��60��65   $��60��6@   $��Right=�5=      ��5<      Z� ��63   Z� .��5?        $
 Menu=�62   ���	#FF7F5D00$��25��5@   2   $��25��5A   2   6@   5B      5D      � 5E      .+�5F      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TransitionMenuContent��5F   :   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6Y   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.2X�.��5G      � -   5        $ 
GridCursor��5G      $��0 0 0 0q�63   
�������$��5��6W   $	��Top=�6a   $
��Left=�6y   $��60��6�   6�   5H      �� 5J      -   5         ��Name$ ListViewMenu��5J      $��Disabled=�65   
�������.@�5L      �� $��60��6'   .��5M      �� $ 
Horizontal=�6)   .+�5N   "     $ ViewDashboard=�6:   $��25��6O   $��25��6Z   $��Center=�6f   $��10q�6�   6�   �� 5O   "   $��
Danh sách��6,   $��Center=�6=   $��20 10q�6X   6i   5P      5Q      �� 5R      $��60��6'   .��5S      �� $ 
Horizontal=�6)   .+�5T   "     $ ViewDashboard=�6:   $��25��6O   $��25��6Z   $��Center=�6f   $��10q�6�   6�   �� 5U   "   $��
Danh sách��6,   $��Center=�6=   $��20 10q�6X   6i   5V      5W      �� 5X      $��60��6'   .��5Y      �� $ 
Horizontal=�6)   .+�5Z   "     $ ViewDashboard=�6:   $��25��6O   $��25��6Z   $��Center=�6f   $��10q�6�   6�   �� 5[   "   $��
Danh sách��6,   $��Center=�6=   $��20 10q�6X   6i   5\      5]      �� 5^      $��60��6'   .��5_      �� $ 
Horizontal=�6)   .+�5`   "     $ ViewDashboard=�6:   $��25��6O   $��25��6Z   $��Center=�6f   $��10q�6�   6�   �� 5a   "   $��
Danh sách��6,   $��Center=�6=   $��20 10q�6X   6i   5b      5c      5d      5f      5g      5h       � 5i   
   -	   5          �Name$ 	HomeFrame��5i      $��	60 70 0 0q�6#   68   5j      5k      
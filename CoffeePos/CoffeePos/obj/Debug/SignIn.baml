   M S B A M L   `   `   `  ����D  @CoffeePos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CoffeePos	CoffeePos  5   	       CoffeePos.SignIn   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CoffeePos     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  SignIn��5	   	   $	��550��6   $	��800��6%    � ShowInTaskbar .   � AllowsTransparency .  � WindowStyle$
 None=�6a    � WindowStartupLocation$ CenterScreen=�6t   .��5
      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  $��1��6.   $��Stretch=�5   %   $��Stretch=�5   %   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffects 5      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  5         Kind$ FadeIn=�62   6B     5      $ SlideInFromRight=�62   6L   .��5   
   #  MaterialDesignThemes.Wpf.Card  .��5      �� $4��./Image/clem-onojeghuo-zlABb6Gke24-unsplash.jpg��6   $
��Fill=�6P    �� StretchDirection$
 Both=�6_   5      5      5      � 5   
   $��0��6   $��Center=�6   	 � RowDefinitions	 5      �� 5      6"   �� 5       6"   �� 5!      6"   �� 5"      6"   �� 5#      6"   .+�5%      �� $��0��6    $   MaterialDesignHeadline5TextBlock#��[  5&      $��Center=�5'      Create Account5)      �� 5*      
 �� Orientation$
 
Horizontal=�6   $��1��62   $��0 10 0 0q�6?   $��Center=�6Q   .+�5+      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Account=�6*   $��Center=�5,   *   $��0,5,10,0q�5-   k   ��6*   ��  �� ElementName$ NameTextBox�� �� Path$ BorderBrush�6k   �� 5.      -   5         ��Name$ NameTextBox��5.       % !MaterialDesignFloatingHintTextBox#��[ 5/      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ UserName��50      $	��170��6F   $��Stretch=�6R   51      �� 52      $
 
Horizontal=�6   $��2��62   $��0 20 0 0q�6?   $��Center=�6Q   .+�53        $	 Key=�6*   $��Center=�54   *   $��0,5,10,0q�55   k   ��6*   �� $ PassWordBox��$ BorderBrush�6k   G� 56      -   5         G�Name$ PassWordBox��56       ) %MaterialDesignFloatingHintPasswordBox#��[ 57         
Foreground
 � � �.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 � � �$ Password��5:      $	��170��6H   $��Stretch=�6T   5;      �� 5<      $
 
Horizontal=�6   $��3��62   $��0 20 0 0q�6?   $��Center=�6Q   .+�5=        $	 Key=�6*   $��Center=�5>   *   $��0,5,10,0q�5?   m   ��6*   �� $ RePassWordBox��$ BorderBrush�6m   G� 5@      -   5        $ RePassWordBox��5@      #��[ 5A      
 � � �
 � � �$ Confirm Password��5D      $	��170��6P   $��Stretch=�6\   5E      �� 5F      $��4��6   $
 
Horizontal=�6&   $��Center=�6?   $��0,30,0,0q�6\   .+�5H      ��   MaterialDesignRaisedButton#��[ 6   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��5I      $��30��5J      $��80��5K      .��6$   Create5M      5N      5O      5P      5Q      
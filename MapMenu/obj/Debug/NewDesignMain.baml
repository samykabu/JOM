   M S B A M L   `   `   `  ����D  @ZonesList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ZonesList;assembly=ZonesList	ZonesList  5      K GWpfZommPanCanvas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:WpfZommPanCanvas;assembly=WpfZommPanCanvasWpfZommPanCanvas 5      I EInterActiveMap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:InterActiveMap;assembly=InterActiveMapInterActiveMap 5      F BImageButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8+clr-namespace:Controls;assembly=ImageButtonControls 5      I ELocalizedImage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:LocalizedImage;assembly=LocalizedImageLocalizedImage 5       JOM Interactive Report   MapMenu.NewDesignMain   5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5      6z*clr-namespace:ZonesList;assembly=ZonesList    5      SWpfZommPanCanvas8clr-namespace:WpfZommPanCanvas;assembly=WpfZommPanCanvas    5      MInterActiveMap4clr-namespace:InterActiveMap;assembly=InterActiveMap    5      >Controls+clr-namespace:Controls;assembly=ImageButton    5      @L4clr-namespace:LocalizedImage;assembly=LocalizedImage    5      -   5          �Name$  Window��5
       � Title$ Design Main��5      $
��1280��5      $	��720��6    � WindowStyle$
 None=�6    � 
ResizeMode$ NoResize=�6/    � WindowStartupLocation$ CenterScreen=�6E    � Topmost .  
���   � � ShowInTaskbar .   � 	Resources 5   
      GlobeIntro2_wmv g� 	BeginTime	 p� Source
 �� 
TargetName �� TargetProperty O� KeyTime O� Value��%  &	        �� 5   
   .��5      p� $ 00:00:00X�6   $	 GlobeIntro3.wmv?�61   $
 GlobeIntro2_wmv��6J   U� 5      $ 00:00:00X�6,   $
 GlobeIntro2_wmv��6A   $ (UIElement.Opacity)�6i   .\�5      �� $ 
00:00:13.5��6'   $ 1Q�6<   �� 5      $ 00:00:14.5000000��6'   $ 0Q�6B   5      U� 5      $ 00:00:00X�6,   $
 InterfaceUI��6A   $ (UIElement.Opacity)�6e   .\�5      �� $ 
00:00:13.5��6'   $ 0Q�6<   �� 5      $ 
00:00:15.0��6'   $ 1Q�6<   5      5      5      .��5   
   �� -   5         ��Name$ 
LayoutRoot��5      $
��1280��6%   $	��720��62   $��0,0,0,0q�6?   .+�5   
   �� -   5        $��Introv��5      $
��1280��6   $	��720��6,   $y�	Collapsed=�69   .+�5      r� -   5         r�Name$ GlobeIntro2_wmv��5   ,   $��0,0,0,0q�6    r� Stretch$
 none=�6E   $
��1280��6T   $	��720��6a   6n   5      �� 5   
   -   5        $��InterfaceUI��5      $
��1280��6$   $	��720��61   $y�Visible=�6>    J� Opacity$ 1Q�6S   .+�5    
   �� $,��&Properties\timeline-top-middelarea.png��6   $
��Fill=�6@   $	��620��6O    �� Left$ 0��6\   
 �� Top$	 100��6l   $
��1280��6}   (� 5!   
   $	��300��6   $	��440��6   $ 119.0��6+   $ 43��6>   .��5"      �� -   5        $	��VVV��5"   O   $
��3422��6   $
��5388��6"   $ 0��60   $ 0��6?   .+�5#      �� $
��3422��6   $
��5388��6*   $ 0��68   $ 0��6G   ��5$      !� 5%       j� Stretch$ Uniform=�6P    !� Visual 6&   ��  �� ElementName$ 
MapViewer1��6P   5'      �� 5(      -   5        $��	ZoomedMap��5(   l   $	��668��6   $	��465��6(   $ 0��65   $ 0��6D   
���  ��$ .4Q�6_   5)      5*      5+      �� 5-   
   $
��Left=�6   $��14.238,109,0,130q�6+   $��320.00��6E   $)��#Properties\timeline-fullmapMask.png��6T   $
��Fill=�6�   $��464.429��6�   $
 2.46��6�   $ 15.771��6�     WpfZommPanCanvas.ZPCanvas  5.   
   -   5        $��InterActiveMap��5.   ?      FullCanvasSize$ 	3422,5388��6$   $��465.0��6U   $	 505��6d   $	 107��6v   $��668.0��6�   }�.  J� SnapsToDevicePixels .     Children. 5/        InterActiveMap.MapViewer  -	   5        $��
MapViewer1��5/   q      BackGroundImage$ zones-2008-12-29.jpg��6'   |�.  K� ZIndex$ 8��6`    .  6�   50      �� 51   
   $��492,94,87,130q�6   $*��$Properties\timeline-zonesmapMask.png��6'   $
��None=�6U   |�.  {�.   J� IsHitTestVisible .  6�     LocalizedImage.LocImage  52      $��0,0,0,0q�6   $	��Top=�6*      AraImage$$ Images\timeline-top-Design.png��6C   $
��1280��6�   $	��107��6�      	IsEnglish 6m   ��  �� Path$ lng.isEnglish�  �� Current! �� Source#! Z  6�      ZonesList.ZonesList  55      -
   5        $��589,49,36,0q�55      $	��Top=�60   $��48��6H   $ 4��6T   $ 12��6c   $	��655��6t   6�     Controls.ImageButton  56      -   5        "   OriginalImage$" /BTImages/HomeBtn.png��56   #   #   MouseOverImage$!# /BTImages/HomeBtn-Hilit.png��6I   $��29.997��6v   $��30��6�   $ 1199.88��6�   $ 12��6�   6�     57      -   5        $"" /BTImages/Turn-offBtn-on.png��57   #   $%# /BTImages/Turn-offBtn-Hilit.png��6P   $��30��6�   $
��Left=�6�   $
 1238��6�   $��30��6�   $ 12��6�   6�     58      -   5        $" /BTImages/ZoominBtn.png��58   #   $## /BTImages/ZoominBtn-Hilit.png��6K   $��30��6z   $��30��6�   $	 515��6�   $ 596.25��6�   6�     59      -   5        $" /BTImages/ZoomoutBtn.png��59   #   $$# /BTImages/ZoomoutBtn-Hilit.png��6L   $��30��6|   $��30��6�   $ 541.25��6�   $ 596.25��6�   6�     5:      -   5        $��EditIcon��5:   �   $!" /BTImages/DataEntryBtn1.png��6#   $'# !/BTImages/DataEntryBtn1-Hilit.png��6O   $��30��6�   $��30��6�   $	 573��6�   $ 596.25��6�   $y�	Collapsed=�6�   6�     5;      -   5        $��ShowDetails��5;   �   $!" /BTImages/MapDetailsBtn.png��6#   $'# !/BTImages/MapDetailsBtn-Hilit.png��6O   $ 1154.659��6�   $	 596��6�   $��47��6�   $��38.341��6�   5<      5>      5?      
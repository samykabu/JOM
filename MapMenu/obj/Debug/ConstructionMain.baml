   M S B A M L   `   `   `  ����G  CYearSelector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:YearSelector;assembly=YearSelectorYearSelector  5      D @ZonesList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ZonesList;assembly=ZonesList	ZonesList 5      K GWpfZommPanCanvas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:WpfZommPanCanvas;assembly=WpfZommPanCanvasWpfZommPanCanvas 5      I EInterActiveMap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:InterActiveMap;assembly=InterActiveMapInterActiveMap 5      F BImageButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8+clr-namespace:Controls;assembly=ImageButtonControls 5      I ELocalizedImage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:LocalizedImage;assembly=LocalizedImageLocalizedImage 5	       JOM Interactive Report   MapMenu.ConstructionMain   5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R	 NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation   	 8x,http://schemas.microsoft.com/winfx/2006/xaml   	 5      <p0clr-namespace:YearSelector;assembly=YearSelector   	 5      6z*clr-namespace:ZonesList;assembly=ZonesList   	 5      SWpfZommPanCanvas8clr-namespace:WpfZommPanCanvas;assembly=WpfZommPanCanvas   	 5      MInterActiveMap4clr-namespace:InterActiveMap;assembly=InterActiveMap   	 5      >Controls+clr-namespace:Controls;assembly=ImageButton   	 5      @L4clr-namespace:LocalizedImage;assembly=LocalizedImage   	 5	      -   5          �Name$  Window��5       � Title$ ConstructionMain��5      $
��1280��5      $	��720��6    � WindowStyle$
 None=�6    � 
ResizeMode$ NoResize=�6/    � WindowStartupLocation$ CenterScreen=�6E    � Topmost .  
���   � � ShowInTaskbar .   � 	Resources 5         GlobeIntro2_wmv g� 	BeginTime	 p� Source
 �� 
TargetName �� TargetProperty O� KeyTime O� Value  	ShowSynop g� Duration R� KeyTime  System.Windows.Visibility   Visible R� Value  	HideSynop   	Collapsed��%�  &	        &	     &	 p    �� 5   
   .��5      p� $ 00:00:00X�6   $	 GlobeIntro3.wmv?�61   $
 GlobeIntro2_wmv��6J   U� 5      $ 00:00:00X�6,   $
 GlobeIntro2_wmv��6A   $ (UIElement.Opacity)�6i   .\�5      �� $ 
00:00:13.5��6'   $ 1Q�6<   �� 5      $ 00:00:14.5000000��6'   $ 0Q�6B   5      U� 5      $ 00:00:00X�6,   $
 InterfaceUI��6A   $ (UIElement.Opacity)�6e   .\�5      �� $ 
00:00:13.5��6'   $ 0Q�6<   �� 5      $ 
00:00:15.0��6'   $ 1Q�6<   5      5      �� 5   
   .��5      T� $ 00:00:00X�6,   $ 00:00:00.0010000D�6A   $
 SynopCanvas��6]   $ (UIElement.Visibility)�6�   ..�5      i� $ 00:00:00��6#   # Z 66   5      U� 5      $ 00:00:00X�6)   $
 SynopCanvas��6>   $ (UIElement.Opacity)�6b   .\�5      �� $ 00:00:00��6!   $ 0.395Q�64   �� 5       $ 00:00:00.5000000��6!   $ 1Q�6<   5!      U� 5"      $ 00:00:00X�6)   $
 SynopCanvas��6>   $ (Canvas.Left)�6b   .\�5#      �� $ 00:00:00��6!   $ -550.222Q�64   �� 5$      $ 00:00:00.5000000��6!   $ 8.222Q�6<   5%      5&      �� 5'   
   .��5(      T� $ 00:00:00X�6)   $ 00:00:00.0010000D�6>   $
 SynopCanvas��6Z   $ (UIElement.Visibility)�6~   ..�5)      i� $ 00:00:00��6#   # Z 66   5*      U� 5+      $ 00:00:00X�6)   $
 SynopCanvas��6>   $ (UIElement.Opacity)�6b   .\�5,      �� $ 00:00:00��6!   $ 1Q�64   �� 5-      $ 00:00:00.5000000��6!   $	 0.4Q�6<   5.      U� 5/      $ 00:00:00X�6)   $
 SynopCanvas��6>   $ (Canvas.Left)�6b   .\�50      �� $ 00:00:00��6!   $ 8.222Q�64   �� 51      $ 00:00:00.5000000��6!   $
 -550Q�6<   52      T� 53      $ 	00:00:0.5X�6,   $ 00:00:00.0010000D�6B   $
 SynopCanvas��6^   $ (UIElement.Visibility)�6�   ..�54      i� $ 00:00:00��6)   # Z 6<   55      56      57      .��5:      �� -   5         ��Name$ 
LayoutRoot��5:      $
��1280��6!   $	��720��6.   $��0,0,0,0q�6;   .+�5<   
   �� -   5        $��Introv��5<      $
��1280��6   $	��720��6,   $y�	Collapsed=�69   .+�5=      r� -   5         r�Name$ GlobeIntro2_wmv��5=   ,   $��0,0,0,0q�6    r� Stretch$
 none=�6E   $
��1280��6T   $	��720��6a   6n   5>      �� 5?   
   -   5        $��InterfaceUI��5?      $
��1280��6$   $	��720��61   $y�Visible=�6>    J� Opacity$ 1Q�6S   .+�5@   
   �� $,��&Properties\timeline-top-middelarea.png��6   $
��Fill=�6@   $	��538��6O    �� Left$ 0��6\   
 �� Top$	 100��6l   $
��1280��6}   (� 5A   
   $	��300��6   $	��440��6   $ 119.0��6+   $ 43��6>   .��5B      �� -   5        $	��VVV��5B   O   $
��3422��6   $
��5388��6"   $ 0��60   $ 0��6?   .+�5C      �� $
��3422��6   $
��5388��6*   $ 0��68   $ 0��6G   ��5D      !� 5E       j� Stretch$ Uniform=�6P    !� Visual 6&   ��  �� ElementName$ 
MapViewer1��6P   5G      �� 5H      -   5        $��	ZoomedMap��5H   l   $	��668��6   $	��465��6(   $ 0��65   $ 0��6D   
���  ��$ .4Q�6_   5I      5J      5K      �� 5M   
   $
��Left=�6   $��14.238,109,0,130q�6+   $��320.00��6E   $)��#Properties\timeline-fullmapMask.png��6T   $
��Fill=�6�   $��464.429��6�   $
 2.46��6�   $ 15.771��6�     WpfZommPanCanvas.ZPCanvas  5N   
   -   5        $��InterActiveMap��5N   ?      FullCanvasSize$ 	3422,5388��6$   $��465.0��6U   $ 580.116��6d   $	 107��6z   $��668.467��6�   }�.    Children. 5O        InterActiveMap.MapViewer  -	   5        $��
MapViewer1��5O   I   |�.  K� ZIndex$ 8��68      BackGroundImage$ zones-2008-12-29.jpg��6�   6�   5P      �� 5Q   
   $��492,94,87,130q�6   $*��$Properties\timeline-zonesmapMask.png��6'   $
��None=�6U   |�.  {�.    J� IsHitTestVisible  .  $ 71.681��6�   $��701.807��6�     LocalizedImage.LocImage  5R   
   $��0,0,0,0q�6   $	��Top=�6&   !   AraImage$+! %Images\timeline-top-Constructions.png��6?   $
��1280��6�   $	��107��6�   "   	IsEnglish" 6p   �� # �� Path$# lng.isEnglish�$ �� Current% �� Source#% Z$ 6�      YearSelector.YearSelector  5S   
   -
   5        $��	ySelector��5S   A   $��82��6   $��Bottom=�6&   $ 0��6R   $	 638��6b   $��704.497��6s   6�     ZonesList.ZonesList  5T      -   5        $��589,49,36,0q�5T      $	��Top=�60   $��59.994��6H   $ 4.444��6X   $ 0��6k   $��655.49��6{   6�     Controls.ImageButton  5U      -   5        &   OriginalImage$& /BTImages/HomeBtn.png��5U   #   '   MouseOverImage$!' /BTImages/HomeBtn-Hilit.png��6I   $��29.997��6v   $��30��6�   $ 1199.88��6�   $ 12��6�   6�     5V      -   5        $"& /BTImages/Turn-offBtn-on.png��5V   #   $%' /BTImages/Turn-offBtn-Hilit.png��6P   $��30��6�   $
��Left=�6�   $
 1238��6�   $��30��6�   $ 12��6�   6�     5W      -   5        ( � ToolTip$( Zoom in��5W   #   $& /BTImages/ZoominBtn.png��65   $#' /BTImages/ZoominBtn-Hilit.png��6]   $��30��6�   $��30��6�   $	 598��6�   $	 596��6�   6�     5X      -   5        $( Zoom out��5X   #   $& /BTImages/ZoomoutBtn.png��67   $$' /BTImages/ZoomoutBtn-Hilit.png��6`   $��30��6�   $��30��6�   $	 625��6�   $ 596.25��6�   6�     5Y      -   5        $��EditIcon��5Y     $( Show entry form��6#   $!& /BTImages/DataEntryBtn1.png��6=   $'' !/BTImages/DataEntryBtn1-Hilit.png��6i   $��30��6�   $��30��6�   $	 658��6�   $ 596.25��6�   $y�	Collapsed=�6�   6    5Z      -   5        $��ShowDetails��5Z   �   $( Display data��6#   $!& /BTImages/MapDetailsBtn.png��6;   $'' !/BTImages/MapDetailsBtn-Hilit.png��6g   $ 1201.659��6�   $ 578.449��6�   $��46.676��6�   $��38.341��6  5[      �� 5]   
   -   5        $��SynopCanvas��5]   9   $ 8.222��6   $ 197.5��6%   $y�	Collapsed=�6L   |�.   . $	��399��6�   $	��565��6�   }�. .+�5^      �� $ ��Images\SynoposisScreen.png��6   �� 5_      -   5        $��
SynopTitle��5_   D   $ 14.444��6   $ 1��6)   $��51��68   $��549.945��6V   $��24(�6f   
�������$��Center=�6�   $��Center=�6�   $
��Bold"�6�   $��Simplified Arabic)�6�   .��6�   Label6  �� 5`      -   5        $��SynopImg��5`   >   $ 14.222��6   $ 47.662��6)   $
��Fill=�6N   $��307.747��6^   $��544.501��6o   $y�Visible=�6   r� 5a      -   5        $��VideoSynopElm��5a      $ Uniform=�61   $ 14.222��6D   $ 47.662��6Y   $��307.747��6m   $��544.501��6~   $y�	Collapsed=�6�   ) r� LoadedBehavior$) Manual=�6�   6�     5b      -   5        $��ImageIconBT��5b   �   $& /Images/ImageIcon.png��6#   $!' /Images/ImageIcon-Hilit.png��6I   $��30��6v   $��30��6�   $ 483.75��6�   $	 345��6�   $y�	Collapsed=�6�   $	 100��6�     5c      -   5        $��VideoIconBT��5c   �   $& /Images/VideoIcon.png��6#   $!' /Images/VideoIcon-Hilit.png��6I   $��30��6v   $��30��6�   $	 520��6�   $	 345��6�   $y�	Collapsed=�6�   $	 100��6�   5d      5e      5f      
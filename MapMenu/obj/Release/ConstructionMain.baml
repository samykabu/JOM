   M S B A M L   `   `   `  ���� G  CYearSelector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:YearSelector;assembly=YearSelectorYearSelector  D @ZonesList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ZonesList;assembly=ZonesList	ZonesList K GWpfZommPanCanvas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:WpfZommPanCanvas;assembly=WpfZommPanCanvasWpfZommPanCanvas I EInterActiveMap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:InterActiveMap;assembly=InterActiveMapInterActiveMap F BImageButton, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8+clr-namespace:Controls;assembly=ImageButtonControls I ELocalizedImage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:LocalizedImage;assembly=LocalizedImageLocalizedImage  ArcView Demo   MapMenu.ConstructionMain   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R	 NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation   	 8x,http://schemas.microsoft.com/winfx/2006/xaml   	 <p0clr-namespace:YearSelector;assembly=YearSelector   	 6z*clr-namespace:ZonesList;assembly=ZonesList   	 SWpfZommPanCanvas8clr-namespace:WpfZommPanCanvas;assembly=WpfZommPanCanvas   	 MInterActiveMap4clr-namespace:InterActiveMap;assembly=InterActiveMap   	 >Controls+clr-namespace:Controls;assembly=ImageButton   	 @L4clr-namespace:LocalizedImage;assembly=LocalizedImage   	 -     �Name$  Window�� � Title$ ConstructionMain��$
��1280��$	��720�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � Topmost .  
���   � � ShowInTaskbar .   � 	Resources    GlobeIntro2_wmv g� 	BeginTime	 p� Source
 �� 
TargetName �� TargetProperty O� KeyTime O� Value  	ShowSynop g� Duration R� KeyTime  System.Windows.Visibility   Visible R� Value  	HideSynop   	Collapsed��%�  &	        &	 P    &	 �    �� .��p� $ 00:00:00X�$	 GlobeIntro3.wmv?�$
 GlobeIntro2_wmv��U� $ 00:00:00X�$
 GlobeIntro2_wmv��$ (UIElement.Opacity)�.\��� $ 
00:00:13.5��$ 1Q��� $ 00:00:14.5000000��$ 0Q�U� $ 00:00:00X�$
 InterfaceUI��$ (UIElement.Opacity)�.\��� $ 
00:00:13.5��$ 0Q��� $ 
00:00:15.0��$ 1Q��� .��T� $ 00:00:00X�$ 00:00:00.0010000D�$
 SynopCanvas��$ (UIElement.Visibility)�..�i� $ 00:00:00��# Z U� $ 00:00:00X�$
 SynopCanvas��$ (UIElement.Opacity)�.\��� $ 00:00:00��$ 0.395Q��� $ 00:00:00.5000000��$ 1Q�U� $ 00:00:00X�$
 SynopCanvas��$ (Canvas.Left)�.\��� $ 00:00:00��$ -550.222Q��� $ 00:00:00.5000000��$ 8.222Q��� .��T� $ 00:00:00X�$ 00:00:00.0010000D�$
 SynopCanvas��$ (UIElement.Visibility)�..�i� $ 00:00:00��# Z U� $ 00:00:00X�$
 SynopCanvas��$ (UIElement.Opacity)�.\��� $ 00:00:00��$ 1Q��� $ 00:00:00.5000000��$	 0.4Q�U� $ 00:00:00X�$
 SynopCanvas��$ (Canvas.Left)�.\��� $ 00:00:00��$ 8.222Q��� $ 00:00:00.5000000��$
 -550Q�T� $ 	00:00:0.5X�$ 00:00:00.0010000D�$
 SynopCanvas��$ (UIElement.Visibility)�..�i� $ 00:00:00��# Z .���� -    ��Name$ 
LayoutRoot��$
��1280��$	��720��$��0,0,0,0q�.+��� -   $��Introv��$
��1280��$	��720��$y�	Collapsed=�.+�r� -    r�Name$ GlobeIntro2_wmv��$��0,0,0,0q� r� Stretch$
 none=�$
��1280��$	��720���� -   $��InterfaceUI��$
��1280��$	��720��$y�Visible=� J� Opacity$ 1Q�.+��� $,��&Properties\timeline-top-middelarea.png��$
��Fill=�$	��538�� �� Left$ 0��
 �� Top$	 100��$
��1280��(� $	��300��$	��440��$ 119.0��$ 43��.���� -   $	��VVV��$
��3422��$
��5388��$ 0��$ 0��.+��� $
��3422��$
��5388��$ 0��$ 0����!�  j� Stretch$ Uniform=� !� Visual ��  �� ElementName$ 
MapViewer1���� -   $��	ZoomedMap��$	��668��$	��465��$ 0��$ 0��
���  ��$ .4Q��� $
��Left=�$��14.238,109,0,130q�$��320.00��$)��#Properties\timeline-fullmapMask.png��$
��Fill=�$��464.429��$
 2.46��$ 15.771��  WpfZommPanCanvas.ZPCanvas  -   $��InterActiveMap��   FullCanvasSize$ 	3422,5388��$��465.0��$ 580.116��$	 107��$��668.467��}�.    Children.   InterActiveMap.MapViewer  -	   $��
MapViewer1��|�.  K� ZIndex$ 8��   BackGroundImage$ zones-2008-12-29.jpg���� $��492,94,87,130q�$*��$Properties\timeline-zonesmapMask.png��$
��None=�|�.  {�.    J� IsHitTestVisible  .  $ 71.681��$��701.807��  LocalizedImage.LocImage  $��0,0,0,0q�$	��Top=�!   AraImage$+! %Images\timeline-top-Constructions.png��$
��1280��$	��107��"   	IsEnglish" �� # �� Path$# lng.isEnglish�$ �� Current% �� Source#% Z$    YearSelector.YearSelector  -
   $��	ySelector��$��82��$��Bottom=�$ 0��$	 638��$��704.497��  ZonesList.ZonesList  -   $��589,49,36,0q�$	��Top=�$��59.994��$ 4.444��$ 0��$��655.49��  Controls.ImageButton  -   &   OriginalImage$& /BTImages/HomeBtn.png��'   MouseOverImage$!' /BTImages/HomeBtn-Hilit.png��$��29.997��$��30��$ 1199.88��$ 12��  -   $"& /BTImages/Turn-offBtn-on.png��$%' /BTImages/Turn-offBtn-Hilit.png��$��30��$
��Left=�$
 1238��$��30��$ 12��  -   ( � ToolTip$( Zoom in��$& /BTImages/ZoominBtn.png��$#' /BTImages/ZoominBtn-Hilit.png��$��30��$��30��$	 598��$	 596��  -   $( Zoom out��$& /BTImages/ZoomoutBtn.png��$$' /BTImages/ZoomoutBtn-Hilit.png��$��30��$��30��$	 625��$ 596.25��  -   $��EditIcon��$( Show entry form��$!& /BTImages/DataEntryBtn1.png��$'' !/BTImages/DataEntryBtn1-Hilit.png��$��30��$��30��$	 658��$ 596.25��$y�	Collapsed=�  -   $��ShowDetails��$( Display data��$!& /BTImages/MapDetailsBtn.png��$'' !/BTImages/MapDetailsBtn-Hilit.png��$ 1201.659��$ 578.449��$��46.676��$��38.341���� -   $��SynopCanvas��$ 8.222��$ 197.5��$y�	Collapsed=�|�.   . $	��399��$	��565��}�. .+��� $ ��Images\SynoposisScreen.png���� -   $��
SynopTitle��$ 14.444��$ 1��$��51��$��549.945��$��24(�
�������$��Center=�$��Center=�$
��Bold"�$��Simplified Arabic)�.��Label�� -   $��SynopImg��$ 14.222��$ 47.662��$
��Fill=�$��307.747��$��544.501��$y�Visible=�r� -   $��VideoSynopElm��$ Uniform=�$ 14.222��$ 47.662��$��307.747��$��544.501��$y�	Collapsed=�) r� LoadedBehavior$) Manual=�  -   $��ImageIconBT��$& /Images/ImageIcon.png��$!' /Images/ImageIcon-Hilit.png��$��30��$��30��$ 483.75��$	 345��$y�	Collapsed=�$	 100��  -   $��VideoIconBT��$& /Images/VideoIcon.png��$!' /Images/VideoIcon-Hilit.png��$��30��$��30��$	 520��$	 345��$y�	Collapsed=�$	 100��
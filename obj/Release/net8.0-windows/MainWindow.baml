   M S B A M L   `   `   `  ���� K  GMansionMapEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MansionMapEditorMansionMapEditor  !    MansionMapEditor.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:MansionMapEditor       � Title$  MansionMapEditor��$	��532��$	��961������  �� Opacity$
 0.19Q� �� ImageSource$ /Castillo.png�� j� Stretch$ UniformToFill=�.���� -    ��Name$ Canvas��.+��� -    ��Name$ ConnectButton��$��Connect��$	��105��$��24��$
��Left=� �� Left$	 378��
 �� Top$ 71��$	��Top=��� -   $ DisconnectButton��$��
Disconnect��$	��105��$��26��$
��Left=�$	 378��$	 100��$	��Top=��� -   $ InitializeButton��$��
Initialize��$	��105��$��26��$	 378��$	 131��$��Center=�$	��Top=��� $��Server��$ 35��$ 70��$	��116�����	#FF5CFF45$��Center=�$��Center=���Z� �� -    ��Name$ 
ServerText��$ 87��	 �� TextWrapping$
	 Wrap=�$ 74��$	��169��$��Center=�$��Center=��� $��Database��$ 35��$ 24��$	��448�����	#FF357933
�������$��Center=�$��Center=��� -   $ PortText��$	 300��$
	 Wrap=�$ 72��$��56��$��Center=�$��Center=��� $
��Port��$	 262��$ 67��$��38�����	#FF5CFF45$��Center=�$��Center=���Z� �� $
��User��$ 36��$ 94��$	��116�����	#FF5CFF45$��Center=�$��Center=���Z� �� -   $ UserText��$ 88��$
	 Wrap=�$	 100��$��99��$��Center=�$��Center=��� $
��Pass��$	 192��$ 93��$	��116�����	#FF5CFF45$��Center=�$��Center=���Z� �� -   $ PassText��$	 236��$
	 Wrap=�$	 100��$	��120��$��Center=�$��Center=��� $��DB��$ 35��$	 122��$	��116�����	#FF5CFF45$��Center=�$��Center=���Z� �� -	   $ DBText��$ 88��$
	 Wrap=�$	 126��$��99��$��Center=�$��Center=��� $	��732��$ 10�����	#FF308809$	 203��$	��498��$��Center=�$��Center=�	� -
   
 	�Name$
 EditRoomsRadioButton��$��Rooms��$ 51��$	 222�����	#FF23CC45$��Center=�$��Center=� d� 	IsChecked$
 TrueY�	� -   $
 EditCharactersRadioButton��$��
Characters��$	 128��$	 222�����	#FF23CC45$��Center=�$��Center=��� -   $ RoomsCanvas��$	��945��$	��519��$��Center=�$	��Top=�.+��� -   $ RoomNameText��$	 188��$
	 Wrap=�$	 318��$	��177��$��Center=�$	��Top=��� $
��Name��$	 129��$	 312��$��74�����	#FF5CFF45$��Center=�$	��Top=���Z� �� $��Description��$ 35��$	 352��$��74�����	#FF5CFF45$��Center=�$	��Top=���Z� �� -   $ RoomDescriptionText��$	 114��$
	 Wrap=�$	 352��$	��251��$��34��$��Center=�$	��Top=��� -   $ RoomListUpdateButton��$��Update��$	��105��$��24��$	 382��$	 608��$��Center=�$	��Top=��� -   $ RoomAddButton��$	��Add��$	��105��$��24��$	 378��$	 350��$��Center=�$	��Top=��� $��Id��$ 35��$	 312��$��74�����	#FF5CFF45$��Center=�$	��Top=���Z� �� -   $ 
RoomIdText��$ 62��$
	 Wrap=�$	 318��$��62��$��Center=�$	��Top=��� -   $ RoomDeleteButton��$��Delete��$	��105��$��24��$	 378��$	 414��$��Center=�$	��Top=��� -   $ RoomNeighbourNText��$	 185��$
	 Wrap=�$	 478��$��78��$��Center=�$	��Top=��� $��
Neighbours��$ 32��$	 446��$��74�����	#FF5CFF45$��Center=�$	��Top=���Z� �� $
��Nord��$	 199��$	 446��$��74�����	#FF5CFF45$��Center=�$	��Top=���Z� �� $
��West��$ 69��$	 496��$��74�����	#FF5CFF45$��Center=�$	��Top=���Z� �� $
��East��$	 345��$	 496��$��74�����	#FF5CFF45$��Center=�$	��Top=���Z� �� -   $ RoomNeighbourWText��$	 111��$
	 Wrap=�$	 501��$��62��$��Center=�$	��Top=��� -   $ RoomNeighbourEText��$	 273��$
	 Wrap=�$	 501��$��66��$��Center=�$	��Top=��� -   $ RoomNeighbourSText��$	 185��$
	 Wrap=�$	 528��$��78��$��Center=�$	��Top=��� $��South��$	 199��$	 546��$��74�����	#FF5CFF45$��Center=�$	��Top=���Z� �� $
��List��$ 35��$	 576��$��74�����	#FF5CFF45$��Center=�$	��Top=���Z� �� -   $ RoomBackgroundText��$	 115��$
	 Wrap=�$	 398��$	��250��$��Center=�$	��Top=��� $��
Background��$ 36��$	 392��$��74�����	#FF5CFF45$��Center=�$	��Top=���Z� �� -   $ RoomFindButton��$
��Find��$	��105��$��24��$	 378��$	 316��$��Center=�$	��Top=��� -   $ RoomModifyButton��$��Modify��$	��105��$��24��$	 378��$	 382��$��Center=�$	��Top=��� -   $ RoomListText��$ 44��$
	 Wrap=�$	 608��$	��321��$	��294��" �� VerticalScrollBarVisibility$
 Auto=�$��Center=�$	��Top=��� $��Rooms��$ 35��$	 254��$	��448�����	#FF357933
�������$��Center=�$	��Top=��� -   $ CharactersCanvas��$	��945��$	��519��$��Center=�$��Center=�.+��� -   $ CharacterName��$	 188��$
	 Wrap=�$	 318��$	��177��$��Center=�$	��Top=��� $
��Name��$	 129��$	 312��$��74�����	#FF5CFF45$��Center=�$	��Top=���Z� �� -   $ CharacterListUpdateButton��$��Update��$	��105��$��24��$	 382��$	 608��$
��Left=�$��Center=��� -   $ CharacterAddButton��$	��Add��$	��105��$��24��$	 378��$	 350��$��Center=�$	��Top=��� $��Id��$ 35��$	 312��$��74�����	#FF5CFF45$��Center=�$	��Top=���Z� �� -   $ CharacterIdText��$ 62��$
	 Wrap=�$	 318��$��62��$��Center=�$	��Top=��� -    $ CharacterDeleteButton��$��Delete��$	��105��$��24��$	 378��$	 414��$��Center=�$	��Top=��� -!   $ CharacterRoomText��$	 115��$
	 Wrap=�$	 392��$��78��$
��Left=�$	��Top=��� $
��Room��$ 35��$	 388��$��74�����	#FF5CFF45$
��Left=�$	��Top=���Z� �� $
��List��$ 36��$	 576��$��74�����	#FF5CFF45$
��Left=�$��Center=���Z� �� -"   $ CharacterImageText��$	 115��$
	 Wrap=�$	 354��$	��250��$��Center=�$	��Top=��� $��Image��$ 35��$	 350��$��74�����	#FF5CFF45$
��Left=�$	��Top=���Z� �� -#   $ CharacterFindButton��$
��Find��$	��105��$��24��$	 378��$	 316��$��Center=�$	��Top=��� -$   $ CharacterModifyButton��$��Modify��$	��105��$��24��$	 378��$	 382��$��Center=�$	��Top=��� -%   $ CharacterListText��$ 40��$
	 Wrap=�$	 607��$	��321��$	��301��$
 Auto=�$��Center=�$	��Top=��� $��
Characters��$ 35��$	 254��$	��448�����	#FF357933
�������$��Center=�$	��Top=�
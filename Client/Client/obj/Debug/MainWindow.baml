   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ClientClient  5   	       Client.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Client     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� $O��IВведите apiURL, где {cityName} - название города.��6   $
��Left=�6L   $��	10,10,0,0q�6g   $	��Top=�6z   �� 5   
   -   5         ��Name$ apiUrlTextBox��5      $
��Left=�6)   $��	10,41,0,0q�6D    �� TextWrapping$
 Wrap=�6W   $4��.https://localhost:60937/api/Weather/{cityName}��6k   $	��Top=�6�   $	��360��6�   $��24��6�   $��14(�6�   �� 5   
   -   5         ��Name$ DataListBox��5      $��466,59,10,10q�6R   �� 5   
   -   5         ��Name$ 	FetchData��5      $��	FetchData��6$   $
��Left=�68   $��	10,70,0,0q�6S   $	��Top=�6f   $��32��6~   $��70��6�   6�   �� 5   
   $����При ошибке без кода запроса следует изменить порт localhost.
См. нужный в контейнере Docker сервера��6   $
��Left=�6�   $��
10,107,0,0q�6�   $	��Top=�6�   �� 5   
   $��Data
��6   $
��Left=�6)   $��
466,31,0,0q�6D   $	��Top=�6X   5      5      
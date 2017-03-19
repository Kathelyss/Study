var game = {
            size: document.f_size.size.value,
            wall_width: 3,
            cell_size: 20,
            is_finish: false,
			result: 1
        }
 
        var character = {
            size: game.cell_size - game.wall_width - 3,
            curr_vertical_pos: 0,
            curr_horizontal_pos: 0,
            count_of_steps: 0,
                        prev_cell_x: 0,
                        prev_cell_y: 0
        }
               
                character.colour = function(graph, go_to_new) {
                        if (go_to_new)   {
                                colour = "plum";
                        } else {
                                colour = "white";
                        }
                        graph.fillStyle = colour;
                        graph.fillRect(game.cell_size * character.curr_vertical_pos + game.wall_width, game.cell_size * character.curr_horizontal_pos + game.wall_width, character.size, character.size);
                }
               
                character.draw = function(graph)        {
                        graph.fillStyle = "darkviolet";         // рисуем персонажа
                        graph.fillRect(game.cell_size * character.curr_vertical_pos + game.wall_width, game.cell_size * character.curr_horizontal_pos + game.wall_width, character.size, character.size);
                }
               
                character.moveLeft = function(graph)    {
                        if (maze[character.curr_horizontal_pos][character.curr_vertical_pos].left_wall == false)        {
                                var go_to_new = (maze[character.curr_horizontal_pos][character.curr_vertical_pos - 1].have_been_here == 0);
                                character.colour(graph, go_to_new);
                                character.prev_cell_y = character.curr_vertical_pos;
                                character.prev_cell_x = character.curr_horizontal_pos;
                                character.curr_vertical_pos = character.curr_vertical_pos - 1;
                                if (go_to_new) {
									maze[character.curr_horizontal_pos][character.curr_vertical_pos].have_been_here++;
                                } else {
                                    maze[character.prev_cell_x][character.prev_cell_y].have_been_here--;                       
								}
                                character.count_of_steps++;
                                character.draw(graph);
                        }
                }
               
                character.moveRight = function(graph)   {
                        if (maze[character.curr_horizontal_pos][character.curr_vertical_pos].right_wall == false)       {
                                var go_to_new = (maze[character.curr_horizontal_pos][character.curr_vertical_pos + 1].have_been_here == 0);
                                character.colour(graph, go_to_new);
                                character.prev_cell_y = character.curr_vertical_pos;
                                character.prev_cell_x = character.curr_horizontal_pos;
                                character.curr_vertical_pos++;
                                if (go_to_new) {
									maze[character.curr_horizontal_pos][character.curr_vertical_pos].have_been_here++;
                                } else {
									maze[character.prev_cell_x][character.prev_cell_y].have_been_here--;                        
								}
                                character.count_of_steps++;
                                character.draw(graph);
                        }
                }
               
                character.moveUp = function(graph)      {
                        if (maze[character.curr_horizontal_pos][character.curr_vertical_pos].ceiling == false)  {
                                var go_to_new = (maze[character.curr_horizontal_pos - 1][character.curr_vertical_pos].have_been_here == 0);
                                character.colour(graph, go_to_new);
                                character.prev_cell_x = character.curr_horizontal_pos;
                                character.prev_cell_y = character.curr_vertical_pos;
                                character.curr_horizontal_pos = character.curr_horizontal_pos - 1;
                                if (go_to_new) {
									maze[character.curr_horizontal_pos][character.curr_vertical_pos].have_been_here++;
                                } else {
									maze[character.prev_cell_x][character.prev_cell_y].have_been_here--;                         
								}
                                character.count_of_steps++;
                                character.draw(graph);
                        }
                }
               
                character.moveDown = function(graph)    {
                        if (maze[character.curr_horizontal_pos][character.curr_vertical_pos].floor == false)    {
                                var go_to_new = (maze[character.curr_horizontal_pos + 1][character.curr_vertical_pos].have_been_here == 0);
                                character.colour(graph, go_to_new);
                                character.prev_cell_x = character.curr_horizontal_pos;
                                character.prev_cell_y = character.curr_vertical_pos;
                                character.curr_horizontal_pos++;
                                if (go_to_new) {
									maze[character.curr_horizontal_pos][character.curr_vertical_pos].have_been_here++;
                                } else {
									maze[character.prev_cell_x][character.prev_cell_y].have_been_here--;                       
								}
                                character.count_of_steps++;
                                character.draw(graph);
                        }
                }
               
        function cell(number, left_wall, right_wall, floor, ceiling, crotch, have_been_here, on_correct_way) { // constructor for object Maze
            this.number = number;
            this.left_wall = left_wall;
            this.right_wall = right_wall;
            this.floor = floor;
            this.ceiling = ceiling;
            this.crotch = crotch;
            this.have_been_here = have_been_here;
			this.on_correct_way = on_correct_way;
        }
 
 
        var initMaze = function() { // (+)            
            for (var i = 0; i < game.size; i++) {
              maze[i] = new Array(game.size);
          }
          for (var i = 0; i < game.size; i++) {
              for (var j = 0; j < game.size; j++) {
                  maze[i][j] = new cell(0, false, false, false, false, false, 0, false);
              }
          }
      }
 
      var addDigitF = function(index) {
          if (index == 0) {
              for (var i = 0; i < maze[index].length; i++) {
                  maze[index][i].number = i + 1;
                  maze[index][i].ceiling = true;
              }
          } else {
              for (var i = 0; i < maze[index].length; i++) {
                  if (!maze[index][i].ceiling) {
                      maze[index][i].number = maze[index - 1][i].number;
                  } else {
                      maze[index][i].number = index * maze.length + i + 1;
                  }
              }
          }
      }
 
      var randomUnite = function(index) { // (+) index - номер строки
          maze[index][0].left_wall = true;
          maze[index][maze[index].length - 1].right_wall = true;
 
          for (var i = 0; i < maze[index].length - 1; i++) {
              if (maze[index][i].number == maze[index][i + 1].number) // если соседние ячейки из одного множества, то стенка
              {
                  maze[index][i].right_wall = true;
                  maze[index][i + 1].left_wall = true;
              }
          }
 
          for (var i = 0; i < (maze[index].length - 1); i++) {
              if (maze[index][i].number == maze[index][i + 1].number) // если соседние ячейки из одного множества, то стенка
              {
                  maze[index][i].right_wall = true;
                  maze[index][i + 1].left_wall = true;
              } else {
                  if (!maze[index][i].right_wall) {
                      if (Math.random() < 0.5) {
                          var oldNumber = maze[index][i + 1].number;
                          for (var j = 0; j < maze[index].length; j++) {
                              if (maze[index][j].number == oldNumber) {
                                  maze[index][j].number = maze[index][i].number;
                              }
                          }
                      } else {
                          maze[index][i].right_wall = true;
                          maze[index][i + 1].left_wall = true;
                      }
                  }
              }
          }
      }
 
      var randomFloor = function(index) {
          // DO NOT CALL FOR THE LAST ROW
          var haveGot = 0;
          var haveFloor = 0;
          for (var i = 0; i < (maze[index].length - 1); i++) {
              if (maze[index][i].number == maze[index][i + 1].number) {
                  haveGot++;
              }
 
              if ((Math.random() < 0.5) && (haveFloor < haveGot)) {
                  maze[index][i].floor = true;
                  maze[index + 1][i].ceiling = true;
                  haveFloor++;
              }
              if (i == maze[index].length - 2 && maze[index][i].number == maze[index][i + 1].number && haveFloor < haveGot && Math.random() < 0.5) {
                  maze[index][i + 1].floor = true;
                  maze[index + 1][i + 1].ceiling = true;
                  haveFloor++;
              }
 
              if (maze[index][i].number != maze[index][i + 1].number) {
                  haveGot = 0;
                  haveFloor = 0;
              }
          }
      }
 
      var addLastRow = function() {
          var index = maze.length - 1;
          maze[index][0].left_wall = true;
          maze[index][maze[index].length - 1].right_wall = true;
          addDigitF(index);
          for (var i = 0; i < maze[index].length; i++) {
              maze[index][i].floor = true;
          }
          for (var i = 0; i < maze[index].length - 1; i++) {
              if (maze[index][i].number == maze[index][i + 1].number) {
                  maze[index][i].right_wall = true;
                  maze[index][i + 1].left_wall = true;
              } else {
                  var oldNumber = maze[index][i + 1].number;
                  for (var j = 0; j < maze[index].length; j++) {
                      if (maze[index][j].number == oldNumber) {
                          maze[index][j].number = maze[index][i].number;
                      }
                  }
              }
          }
      }
 
      var mazeGen = function() {
          for (var i = 0; i < maze.length - 1; i++) {
              addDigitF(i);
              randomUnite(i);
              randomFloor(i);
          }
          addLastRow();
        }
 
        var addStartFinish = function(graph)    {
			      graph.fillStyle = "darkviolet"; //рисуем вход в лабиринт
            graph.fillRect(game.wall_width, game.wall_width, game.cell_size - 2*game.wall_width, game.cell_size - 2*game.wall_width);
            graph.fillStyle = "limegreen";  // рисуем выход из лабиринта
            graph.fillRect(game.cell_size * (game.size - 1) + game.wall_width, game.cell_size * (game.size - 1) + game.wall_width, game.cell_size - 2*game.wall_width, game.cell_size - 2*game.wall_width);
        }
               
        var draw = function(graph) {
            graph.fillStyle = "white";
            graph.fillRect(0, 0, game.cell_size * game.size, game.cell_size * game.size);
 
            graph.strokeStyle = "#ededed";
            graph.lineWidth = game.wall_width;
            for (var i = 0; i <= maze.length; i++) {
              graph.beginPath();
			  if (i == 0)	{
				graph.strokeStyle = "black";
			  }
			  else
			  {
				graph.strokeStyle = "#ededed";
			  }
              graph.moveTo(i * game.cell_size, 0);
              graph.lineTo(i * game.cell_size, maze.length * game.cell_size);
              graph.stroke();
          }
          for (var i = 0; i <= maze.length; i++) {
              graph.beginPath();
			  if (i == 0)	{
				graph.strokeStyle = "black";
			  }
			  else
			  {
				graph.strokeStyle = "#ededed";
			  }
              graph.moveTo(game.wall_width, i * game.cell_size);
              graph.lineTo(maze.length * game.cell_size, i * game.cell_size);
              graph.stroke();
          }
          graph.strokeStyle = "black";
          for (var i = 0; i < game.size; i++) {
              for (var j = 0; j < game.size; j++) {
                  if (maze[i][j].right_wall == true) {
                      graph.beginPath();
                      graph.moveTo(game.cell_size * (j + 1), game.cell_size * i);
                      graph.lineTo(game.cell_size * (j + 1), game.cell_size * (i + 1));
                      graph.stroke();
                  }
                  if (maze[i][j].floor == true) {
                      graph.beginPath();
                      graph.moveTo(game.cell_size * j, game.cell_size * (i + 1));
                      graph.lineTo(game.cell_size * (j + 1), game.cell_size * (i + 1));
                      graph.stroke();
                  }
              }
          }
                       addStartFinish(graph);
                       character.draw(graph);
      }
	  
			  var getProbability = function()	{
				for (var i = 0; i < maze.length; i++) { // for test with walls and floor
					for (var j = 0; j < maze[i].length; j++) {
						if (maze[i][j].have_been_here != 0)	{
							if (maze[i][j].ceiling == false)	{
								maze[i][j].crotch++;
							}
							if (maze[i][j].floor == false)	{
								maze[i][j].crotch++;
							}
							if (maze[i][j].left_wall == false)	{
								maze[i][j].crotch++;
							}	
							if (maze[i][j].right_wall == false)	{
								maze[i][j].crotch++;
							}	
							if ((maze[i][j].crotch > 2))	{
								game.result = game.result * (maze[i][j].crotch - 1);
							}
							if ((i == 0) && (j == 0))	{
								if (maze[i][j].crotch == 2)	{
									game.result = game.result * maze[i][j].crotch;
								}
							}
						}
					}
				}
			  }
             
			  var checkFinish = function()   {
                       if ((character.curr_horizontal_pos == (game.size - 1)) && (character.curr_vertical_pos == (game.size - 1)))     {
							game.is_finish = true;
							$('#kont2').html('Загрузка...').Load('#kont2win', 'pages/load_non_cycles.html');
							getProbability();
							
							document.getElementById('answer').innerHTML = (game.result);
                       }
                }
			 
               var listen;
               document.body.onkeydown = function (listen) { 
					if (!game.is_finish)	{
						if ((listen.keyCode == 37) || (listen.keyCode == 65 ))  {                       // move left or A
							character.moveLeft(graph);
						}
						if ((listen.keyCode == 38) || (listen.keyCode == 87))   { // move up or W
							character.moveUp(graph);
						}
						if ((listen.keyCode == 39) || (listen.keyCode == 68))   { // move right or D
							character.moveRight(graph);
						}
						if ((listen.keyCode == 40) || (listen.keyCode == 83))   { // move down or S
                            character.moveDown(graph);
						}
						if (listen.keyCode == 72)	{
							drawWay();
							addStartFinish(graph);
						}						
						checkFinish();
					}
               }
             
               
 
      //main()
      var maze = new Array(document.f_size.size.value);
      initMaze();
      mazeGen();
 
      var graph = document.getElementById("canvas").getContext("2d");
      draw(graph);
	  
	   for (var i = 0; i < maze.length; i++) {
              for (var j = 0; j < maze[i].length; j++) {
					maze[i][j].number = -1;
			  }
	   }
	   
	   var checkCell = function(x, y, d)	{
			if ((y > 0) && (!maze[x][y].left_wall) && (maze[x][y - 1].number == -1))	{  // слева
				maze[x][y - 1].number = d + 1;
				checkCell(x, (y - 1), d + 1);
			}
			if ((y < game.size - 1) && (!maze[x][y].right_wall) && (maze[x][y + 1].number == -1))	{ // справа
				maze[x][y + 1].number = d + 1;
				checkCell(x, y + 1, d + 1);
			}
			if ((x > 0) && (!maze[x][y].ceiling) && (maze[x - 1][y].number == -1))	{  // вверх
				maze[x - 1][y].number = d + 1; 
				checkCell(x - 1, y, d + 1);
			}
			if ((x < game.size - 1) && (!maze[x][y].floor) && (maze[x + 1][y].number == -1))	{  // вниз
				maze[x + 1][y].number = d + 1;
				checkCell(x + 1, y , d + 1);				
			}
	  }
	  
	  var drawWay = function()	{
			for (var i = 0; i < maze.length; i++) {
				  for (var j = 0; j < maze[i].length; j++) {
						if ((maze[i][j].have_been_here == 0) && (maze[i][j].on_correct_way))	{
								graph.fillStyle = "#66ff66";
							graph.fillRect(game.cell_size * j + game.wall_width, game.cell_size * i + game.wall_width, character.size, character.size);
						}
				  }
			}
	  }
	  
	  var buildWay = function(x, y)	{
		maze[x][y].on_correct_way = true; 
			if ((y > 0) && (!maze[x][y].left_wall) && (maze[x][y - 1].number == (maze[x][y].number - 1)))	{  // слева
				buildWay(x, (y - 1));
			}
			if ((y < game.size - 1) && (!maze[x][y].right_wall) && (maze[x][y + 1].number == (maze[x][y].number - 1)))	{ // справа
				buildWay(x, (y + 1));
			}
			if ((x > 0) && (!maze[x][y].ceiling) && (maze[x - 1][y].number == (maze[x][y].number - 1)))	{  // вверх
				buildWay((x - 1), y);
			}
			if ((x < game.size - 1) && (!maze[x][y].floor) && (maze[x + 1][y].number == (maze[x][y].number - 1)))	{  // вниз
				buildWay((x + 1), y);				
			}
	  }
	  
	  var d = 0;
	  var findWay = function()	{
			maze[0][0].number = d;
			checkCell(0,0,0);
			buildWay(game.size - 1, game.size - 1);
	  }
	   
	   
	   
	  findWay();
	  
	  for (var i = 0; i < maze.length; i++) {
              for (var j = 0; j < maze[i].length; j++) {
					if (!maze[i][j].on_correct_way)	{
						maze[i][j].number = 0;
					}
			  }
	   }
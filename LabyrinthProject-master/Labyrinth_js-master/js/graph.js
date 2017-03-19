var f = document.getElementById("viewport_1");
f.width = max_cells * cell_size;
f.height = f.width;

var Renderer = function(canvas) {
        var canvas = $(canvas).get(0);
        var ctx = canvas.getContext("2d");
        var particleSystem;

        var that = {
            init: function(system) {
                //начальная инициализация
                particleSystem = system;
                particleSystem.screenSize(canvas.width, canvas.height);
                particleSystem.screenPadding(80);
                that.initMouseHandling();
            },

            redraw: function() {
                //действия при перерисовке
                ctx.fillStyle = "white";
                ctx.fillRect(0, 0, canvas.width, canvas.height);

                //отрисовка граней
                particleSystem.eachEdge(
                    function(edge, pt1, pt2) { //будем работать с гранями и точками её начала и конца
                        ctx.strokeStyle = "rgba(0,0,0, .333)"; //грани: чёрным цветом с прозрачностью
                        ctx.lineWidth = 1; //толщиной в один пиксель
                        ctx.beginPath(); //начинаем рисовать
                        ctx.moveTo(pt1.x, pt1.y); //от точки один
                        ctx.lineTo(pt2.x, pt2.y); //до точки два
                        ctx.stroke();
                    });

                //отрисовка вершин
                particleSystem.eachNode(
                    function(node, pt) { //получаем вершину и точку где она
                        var w = 10; //ширина квадрата
                        ctx.fillStyle = "green"; //с его цветом понятно
                        ctx.fillRect(pt.x - w / 2, pt.y - w / 2, w, w); //рисуем
                        ctx.fillStyle = "black"; //цвет для шрифта
                        ctx.font = '13px Verdana'; //шрифт
                        ctx.fillText(node.name, pt.x + 8, pt.y + 8); //пишем имя у каждой точки
                    });
            },

            initMouseHandling: function() { //события с мышью
                var dragged = null; //вершина которую перемещают
                var handler = {
                        clicked: function(e) { //нажали
                            var pos = $(canvas).offset(); //получаем позицию canvas
                            _mouseP = arbor.Point(e.pageX - pos.left, e.pageY - pos.top); //и позицию нажатия кнопки относительно canvas
                            dragged = particleSystem.nearest(_mouseP); //определяем ближайшую вершину к нажатию
                            if (dragged && dragged.node !== null) {
                                dragged.node.fixed = true;
                            }
                            $(canvas).bind('mousemove', handler.dragged); //слушаем события перемещения мыши
                            $(window).bind('mouseup', handler.dropped); //и отпускания кнопки
                            return false;
                        },
                        dragged: function(e) { //перетаскиваем вершину
                            var pos = $(canvas).offset();
                            var s = arbor.Point(e.pageX - pos.left, e.pageY - pos.top);

                            if (dragged && dragged.node !== null) {
                                var p = particleSystem.fromScreen(s);
                                dragged.node.p = p; //тянем вершину за нажатой мышью
                            }

                            return false;
                        },
                        dropped: function(e) { //отпустили
                            if (dragged === null || dragged.node === undefined) return; //если не перемещали, то уходим
                            if (dragged.node !== null) dragged.node.fixed = false; //если перемещали - отпускаем
                            dragged = null; //очищаем
                            $(canvas).unbind('mousemove', handler.dragged); //перестаём слушать события
                            $(window).unbind('mouseup', handler.dropped);
                            _mouseP = null;
                            return false;
                        }
                    }
                    // слушаем события нажатия мыши
                $(canvas).mousedown(handler.clicked);
            },

        }
        return that;
    }
	
	var verify_all = function(sys) 
	{
		for (var i in leafs) 
			{
				if (!leafs[i].verify(sys)) 
					{
						return document.getElementById('answ').innerHTML= "Граф построен неверно";
					}
			}
		return document.getElementById('answ').innerHTML= "Граф построен верно";
	}

	var add_edge = function(from, to) { //добавление связи
		var eFrom = Math.min(from, to);
		var eTo = Math.max(from, to);
		
		if (sys.getEdges(from, to).length > 0 || sys.getEdges(to, from) > 0) {
			return;
		}
		
		console.log("added: " + eFrom + "->" + eTo);
		sys.addEdge(eFrom, eTo);
//		that.redraw();
	}
	
	var remove_edge = function(from, to) { // удаление связи
		var eFrom = Math.min(from, to);
		var eTo = Math.max(from, to);
		
		var toRemove = sys.getEdges(eFrom, eTo);
		for (var i in toRemove) {
			sys.pruneEdge(toRemove[i]);
		}
	}
    $(document).ready(function() {
        sys = arbor.ParticleSystem(800); // создаём систему
        sys.parameters({
            gravity: true
        });
        sys.renderer = Renderer("#viewport_1") //начинаем рисовать в выбраной области


        var l1 = leafs_with_room[0];
        var l2 = leafs_with_room[leafs_with_room.length - 1];

        for (var i = 0; i < leafs_with_room.length; i++) {
            var l = leafs_with_room[i];
            sys.addNode(l.room.room_number, l.room.room_number);
            /*		for (var j = 0; j < l.room.matrix.length; j++) {
            			var r = l.room.matrix[j];
            			sys.addEdge(l.room.room_number,r.room_number);
            		} */
        }
    })
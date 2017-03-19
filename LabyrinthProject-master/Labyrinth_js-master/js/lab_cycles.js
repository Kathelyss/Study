// Автор: Екатерина Рыжова, ЛЭТИ, ФКТИ, гр. 4302
var max_cells 			= document.f_size.size.value;
var wdt 				= cell_size * max_cells;
var hgt 				= wdt;
var cell_size 			= 13; // размер клетки
var max_leaf_size 		= 15; // максимальный размер листа
var room_num			= 0;
var leafs 				= []; // массив, хранящий все листы
var leafs_with_room 	= []; // массив с крайними листами (те, что содержат комнаты)
var cells 				= []; // массив клеток

var c 					= document.getElementById("canvas_1");
c.width 				= max_cells * cell_size;
c.height 				= c.width;

var ctx 				= c.getContext("2d");
ctx.fillStyle 			= "black";
ctx.font 				= "11px Verdana";
ctx.textAlign 			= "center";

// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
// Вспомогательные функции

function randomBetween(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

//нахождение расстояний между центрами 2х комнат
function compare(rect1, rect2) {
    var x1 = rect1.center.x;
    var x2 = rect2.center.x;
    var y1 = rect1.center.y;
    var y2 = rect2.center.y;
    var result = Math.abs(x1 - x2) + Math.abs(y1 - y2);
    return result;
}

//поиск ближайшей комнаты, к комнате, имеющей только 1 связь
function findNearest(room_leafs) {
    for (i = 0; i < room_leafs.length; i++) {
        var leaf = room_leafs[i];
        var nearest_leaf = 0;
        var minCoeff = 10000;
        if (leaf.room.matrix.length == 1 && Math.random() > 0.5) {
            for (var p in room_leafs) {
                var leaf2 = room_leafs[p];
                var room_coeff = compare(leaf.room, leaf2.room);
                if (room_coeff < minCoeff) {
                    if (leaf2 != leaf && leaf.room.matrix[0] != leaf2.room) {
                        minCoeff = room_coeff;
                        nearest_leaf = leaf2;
                    }
                }
            }
            leaf.createHall(leaf.room, nearest_leaf.room);
        }
    }
}

// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
// конструкторы объектов
function Cell(value, x, y) {
    this.value = value;
    this.x = x;
    this.y = y;
    this.print = function() {
        var offset = 0.25;
        var colors = ["gainsboro", "black", "#999999", "#777777", "#555555"];
        ctx.fillStyle = colors[this.value];
        ctx.fillRect(cell_size * this.x + offset, cell_size * this.y + offset, cell_size - offset, cell_size - offset);
    }
}

function Point(x, y) {
    this.x = x;
    this.y = y;
    this.toString = function() {
        return "{" + this.x + ", " + this.y + "}";
    }
}

function Size(wdt, hgt) {
    this.wdt = wdt;
    this.hgt = hgt;
    this.toString = function() {
        return "{" + this.wdt + ", " + this.hgt + "}";
    }
}

function Room(x, y, wdt, hgt) {
    this.origin 		= new Point(x, y);
    this.size 			= new Size(wdt, hgt);
    this.left 			= x;
    this.right 			= x + wdt;
    this.top 			= y;
    this.bottom 		= y + hgt;
    this.center 		= new Point(Math.floor(x + wdt / 2), Math.floor(y + hgt / 2));
    this.matrix 		= [];
    this.room_number 	= 0;

    this.toString = function() {
        return " {" + this.origin.toString() + ", " + this.size.toString() + "}";
    }
}

//конструктор объекта "лист"
function Leaf(x, y, wdt, hgt) {
    this.x 				= x;
    this.y 				= y;
    this.wdt 			= wdt;
    this.hgt 			= hgt;
    this.min_leaf 		= 5;
    this.left_child 	= 0;
    this.right_child 	= 0;
    this.room 			= 0;
    this.halls 			= [];
    this.tier 			= 0;
    this.split_point_x 	= 0;
    this.split_point_y 	= 0;

    this.print_num_of_room = function() {
        if (this.room != 0) {
            ctx.fillText(this.room.room_number, (this.room.origin.x + this.room.size.wdt / 2) * cell_size, (this.room.origin.y + this.room.size.hgt / 2) * cell_size);
        }
    }

    this.split = function() {
        // если у листа есть потомки, то делить его не нужно
        if (this.left_child != 0 && this.right_child != 0) {
            return false;
        }
        // random возвращает float от 0 до 1
        // делим по вертикали или горизонтали (вероятность 0.5)
        var splitH = (Math.random() > 0.5);
        // если ширина больше высоты на 25% и более - делим по вертикали
        if (this.wdt > this.hgt && this.wdt /this.hgt >= 1.25) {
            splitH = false;
            // иначе - делим по вертикали
        } else if (this.hgt > this.wdt && this.hgt / this.wdt  >= 1.25) {
            splitH = true;
        }
        // определяем максимальный размер листа
        var max = (splitH ? this.hgt : this.wdt) - this.min_leaf;
        // если он не больше минимума - то не делим и возвращаемся
        if (max <= this.min_leaf) {
            return false;
        }

        var split = randomBetween(this.min_leaf, max);

        if (splitH) {
            this.left_child = new Leaf(this.x, this.y, this.wdt, split);
            this.right_child = new Leaf(this.x, this.y + split, this.wdt, this.hgt - split);
            this.split_point_y = this.y + split;
        } else {
            this.left_child = new Leaf(this.x, this.y, split, this.hgt);
            this.right_child = new Leaf(this.x + split, this.y, this.wdt - split, this.hgt);
            this.split_point_x = this.x + split;
        }
        this.left_child.tier = this.tier + 1;
        this.right_child.tier = this.tier + 1;
        return true;
    }

    this.createHall = function(l, r) {
        if (l == 0 || r == 0) return;
        // var point1 = new Point(randomBetween(l.left + 1, l.right - 2), randomBetween(l.top + 1, l.bottom - 2));
        // var point2 = new Point(randomBetween(r.left + 1, r.right - 2), randomBetween(r.top + 1, r.bottom - 2));
        var point1 = l.center;
        var point2 = r.center;
        var w = point2.x - point1.x;
        var h = point2.y - point1.y;
        l.matrix.push(r);
        r.matrix.push(l);

        if (w < 0) {
            if (h < 0) {
                if (Math.random() * 0.5) {
                    this.halls.push(new Room(point2.x, point1.y, Math.abs(w), 1));
                    this.halls.push(new Room(point2.x, point2.y, 1, Math.abs(h)));
                } else {
                    this.halls.push(new Room(point2.x, point2.y, Math.abs(w), 1));
                    this.halls.push(new Room(point1.x, point2.y, 1, Math.abs(h)));
                }
            } else if (h > 0) {
                if (Math.random() * 0.5) {
                    this.halls.push(new Room(point2.x, point1.y, Math.abs(w), 1));
                    this.halls.push(new Room(point2.x, point1.y, 1, Math.abs(h)));
                } else {
                    this.halls.push(new Room(point2.x, point2.y, Math.abs(w), 1));
                    this.halls.push(new Room(point1.x, point1.y, 1, Math.abs(h)));
                }
            } else {
                this.halls.push(new Room(point2.x, point2.y, Math.abs(w), 1));
            }
        } else if (w > 0) {
            if (h < 0) {
                if (Math.random() * 0.5) {
                    this.halls.push(new Room(point1.x, point2.y, Math.abs(w), 1));
                    this.halls.push(new Room(point1.x, point2.y, 1, Math.abs(h)));
                } else {
                    this.halls.push(new Room(point1.x, point1.y, Math.abs(w), 1));
                    this.halls.push(new Room(point2.x, point2.y, 1, Math.abs(h)));
                }
            } else if (h > 0) {
                if (Math.random() * 0.5) {
                    this.halls.push(new Room(point1.x, point1.y, Math.abs(w), 1));
                    this.halls.push(new Room(point2.x, point1.y, 1, Math.abs(h)));
                } else {
                    this.halls.push(new Room(point1.x, point2.y, Math.abs(w), 1));
                    this.halls.push(new Room(point1.x, point1.y, 1, Math.abs(h)));
                }
            } else {
                this.halls.push(new Room(point1.x, point1.y, Math.abs(w), 1));
            }
        } else {
            if (h < 0) {
                this.halls.push(new Room(point2.x, point2.y, 1, Math.abs(h)));
            } else if (h > 0) {
                this.halls.push(new Room(point1.x, point1.y, 1, Math.abs(h)));
            }
        }
    }

    this.createRooms = function() {
        if (this.left_child != 0 && this.right_child != 0) {
            // создать комнату в листах-потомках
            this.left_child.createRooms();
            this.right_child.createRooms();
         } else {
            // в листе можно создать комнату
            var origin;
            var size;
            // если делать комнаты рандомного размера
            // size = new Size(randomBetween(3, this.wdt - 2), randomBetween(3, this.hgt - 2));
            // origin = new Point(randomBetween(1, this.wdt - size.wdt - 1), randomBetween(1, this.hgt - size.hgt -1));
            // делать комнаты занимающие всю площадь листа минус рамка
            size = new Size(this.wdt - 2, this.hgt - 2);
            origin = new Point(1, 1);
            this.room = new Room(this.x + origin.x, this.y + origin.y, size.wdt, size.hgt);
            // добавить этот лист в массив листов с комнатами
            leafs_with_room.push(this);
        }
    }

    this.getNearestRoom = function(kx, ky) {
        if (this.room != 0) {
            return this.room;
        } else {
            var the_room = 0;
            var l = this.left_child;
            var r = this.right_child;
            // console.log("kx %d, ky %d", kx, ky);
            if (kx > 0) {
                // console.log("Get nearest: %d and %d", Math.abs(l.x - kx), Math.abs(r.x - kx));
                if (Math.abs(l.x - kx) < Math.abs(r.x - kx))   the_room = l.getNearestRoom(kx, ky);
                 else the_room = r.getNearestRoom(kx, ky);
            } else {
                if (Math.abs(l.y - ky) < Math.abs(r.y - ky))  the_room = l.getNearestRoom(kx, ky);
                 else the_room = r.getNearestRoom(kx, ky);
            }
            return the_room;
        }
        return 0;
    }

    this.verify = function(sys) {
        if (this.room != 0) {
            var from = this.room.room_number;
            var existing = sys.getEdgesFrom(from).concat(sys.getEdgesTo(from)).length;
            var matched = 0;
			
			console.log("ROOM " + from);

            for (var i in this.room.matrix) {
                var to = this.room.matrix[i].room_number;
                var eFrom = Math.min(from, to);
                var eTo = Math.max(from, to);
                var edges = sys.getEdges(eFrom, eTo);
                if (edges.length == 1) {
                    matched++;
                } else {
					console.log("WRONG: " + eFrom + "; " + eTo + " edges: " + edges.length);
					var temp1 = sys.getEdgesFrom(from);
					for (var j in temp1) {
						console.log("  from exists: " + temp1[j].target.data);
					}
					var temp2 = sys.getEdgesTo(from);
					for (var j in temp2) {
						console.log("  to exists: " + temp2[j].source.data);
					}					
                    return false;
                }
            }

			console.log("Exists:" + existing + "; matched: " + matched);
            return (existing == matched);
        }
        return true;
    }

    this.coutt = function() {
        if (this.room != 0) {
            var str = "Комната " + this.room.room_number + " : ";
            for (var i in this.room.matrix) {
                var room = this.room.matrix[i];
                str = str + room.room_number + ", ";
            }
            return str;
        } else {
            return "";
        }
    }

    this.toString = function() {
        var hasChildren = (this.left_child != 0 && this.right_child != 0) ? " has children " : "";
        var hasRoom = (this.room != 0) ? " has room #" + this.room.room_number + this.room.toString() : "";
        var hasHalls = (this.halls.length) ? "has " + this.halls.length + " halls" : "";
        var coordinates = "{" + this.x + ", " + this.y + ", " + this.wdt + ", " + this.hgt + "}";
        return '<br/>' + "List " + coordinates + hasChildren + hasRoom + hasHalls;
    }
}

// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
// Основной алгоритм
// создание двумерного массива клеток
var i = j = 0;
for (i = 0; i < max_cells; i++) {
    var col = [];
    for (j = 0; j < max_cells; j++) {
        var cell_type = 1;
        col[j] = new Cell(cell_type, i, j);
    }
    cells[i] = col;
}

var l; // вспомогательный лист
// создадим корневой лист
var root = new Leaf(0, 0, max_cells, max_cells);
leafs.push(root);

var did_split = true;
while (did_split) {
    did_split = false;
    for (var next in leafs) {
        l = leafs[next];
        if (l.left_child == 0 && l.right_child == 0) {
            if (l.wdt > max_leaf_size || l.hgt > max_leaf_size || Math.random() > 0.25) {
                if (l.split()) {
                    leafs.push(l.left_child);
                    leafs.push(l.right_child);
                    did_split = true;
                }
            }
        }
    }
}
// создать комнаты
root.createRooms();

// создать проходы
var room_leafs = [];
for (i = 0; i < leafs.length; i++) {
    var leaf = leafs[i];
    if (leaf.room != 0) {
        room_leafs.push(leaf);
    }
    if (leaf.left_child && leaf.right_child) {
        leaf.createHall(leaf.left_child.getNearestRoom(leaf.split_point_x, leaf.split_point_y), leaf.right_child.getNearestRoom(leaf.split_point_x, leaf.split_point_y));
    }
}

//создать циклы
findNearest(room_leafs);

var num = 1;
// записать в массив клеток клетки проходов
for (var next in leafs) {
    l = leafs[next];
    if (l.room != 0) {
        l.room.room_number = num;
        num++;
    }
    
    if (l.halls.length) {
        for (var next in l.halls) {
            var hall = l.halls[next];
            for (i = 0; i < hall.size.wdt; i++) {
                for (j = 0; j < hall.size.hgt; j++) {
                    var cell = cells[hall.origin.x + i][hall.origin.y + j];
                    cell.value = 3;
                }
            }
        }
    }
}

// записать в массив клеток клетки комнат
for (var next in leafs_with_room) {
	l = leafs_with_room[next];
	var room = l.room;
        for (i = 0; i < room.size.wdt; i++) {
            for (j = 0; j < room.size.hgt; j++) {
                var cell = cells[room.origin.x + i][room.origin.y + j];
                cell.value = 0;
            }
        }
}

// печать всех клеток
for (i = 0; i < max_cells; i++) {
    for (j = 0; j < max_cells; j++) {
        var cell = cells[i][j];
        cell.print();
    }
}

// печать номеров комнат
for (i = 0; i < leafs.length; i++) {
    var leaf = leafs[i];
    leaf.print_num_of_room();
}

var str = "";
// печать связей комнат
for (i = 0; i < leafs.length; i++) {
    var leaf = leafs[i];
    var s = leaf.coutt();
    str += s;
    if (s != "") str += "<br/>";
}
document.getElementById("demo").innerHTML = str;



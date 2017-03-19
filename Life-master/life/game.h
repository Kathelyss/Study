#include <vector>
#include <iostream>
typedef std::vector<std::vector<bool> > matrix;
typedef unsigned int uint;

/* Functions implement game logic */
namespace Game {
    
    // Returns blaaaank field where nobody is alive
    matrix *getBlankField(size_t rows, size_t cols) {
        matrix *field = new matrix();
        // Add rows...
        for (uint i = 0; i < rows; i++) {
            field->push_back(std::vector<bool>());
            // ... and values into the row
            for (uint j = 0; j < cols; j++) {
                (field->at(i)).push_back(false);
            }
        }
        return field;
    }
    
    // Returns rows number
    size_t getRows(const matrix &field) {
        return field.size();
    }
    
    // Returns cols number
    size_t getCols(const matrix &field) {
        if (getRows(field) != 0) {
            return field[0].size();
        }
        return -1;
    }
    
    // ======================= YOUR CODE HERE =======================
    void copy(matrix &oldField, matrix field){
        for (uint i = 0; i < field.size(); i++) {
            for (uint j = 0; j < field[0].size(); j++) {
                oldField[i][j] = field[i][j];
            }
        }
    }
    void step(matrix &field){
        int row = (int)field.size()-1,
            col = (int)field[0].size()-1,
            mur = 1;
        matrix ofield = *getBlankField(field.size(), field[0].size());
        copy(ofield, field);
        
        for (uint i = 0; i <= row; i++) {
            for (uint j = 0; j <= col; j++) {
                uint count = 0;
                for(int x = -mur;x<=mur;x++){
                    for(int y = -mur;y<=mur;y++){
                        if( x == 0 && y == 0 ) continue;
                        int a = i+x,
                            b = j+y;
                        if(ofield
                           [a < mur-1 ? row : (a > row ? 0: a)]
                           [b < mur-1 ? col : (b > col ? 0: b)])count++;
                    }
                }
                //std::cout<<count<<" ";
                
                if (field[i][j]) {
                    if (count >= 2 && count <= 3){
                        field[i][j] = true;
                    } else {
                        field[i][j] = false;
                    }
                } else if (count == 3){
                        field[i][j] = true;
                }
            }
        }
    }
    bool isEqual(matrix oldField, matrix field){
        for (uint i = 0; i < field.size(); i++) {
            for (uint j = 0; j < field[0].size(); j++) {
                if(oldField[i][j] != field[i][j]){
                    return false;
                };
            }
        }
        return true;
    }
    
    void final(matrix &field){
        int row = (int)field.size()-1,
            col = (int)field[0].size()-1,
            h = 0,
            x = (row/2)-5,
            y = (col/2)-13;
        
        field[x+2][y+2] = true;
        field[x+3][y+2] = true;
        field[x+4][y+2] = true;
        field[x+5][y+2] = true;
        field[x+6][y+2] = true;
        field[x+4][y+3] = true;
        field[x+2][y+4] = true;
        field[x+3][y+4] = true;
        field[x+5][y+4] = true;
        field[x+6][y+4] = true;
        
        field[x+2][y+6] = true;
        field[x+3][y+6] = true;
        field[x+4][y+6] = true;
        field[x+5][y+6] = true;
        field[x+6][y+6] = true;
        field[x+2][y+7] = true;
        field[x+6][y+7] = true;
        field[x+2][y+8] = true;
        field[x+3][y+8] = true;
        field[x+4][y+8] = true;
        field[x+5][y+8] = true;
        field[x+6][y+8] = true;
        
        field[x+2][y+10] = true;
        field[x+3][y+10] = true;
        field[x+4][y+10] = true;
        field[x+5][y+10] = true;
        field[x+6][y+10] = true;
        field[x+4][y+11] = true;
        field[x+2][y+12] = true;
        field[x+3][y+12] = true;
        field[x+4][y+12] = true;
        field[x+5][y+12] = true;
        field[x+6][y+12] = true;
        
        field[x+2][y+14] = true;
        field[x+3][y+14] = true;
        field[x+4][y+14] = true;
        field[x+5][y+14] = true;
        field[x+6][y+14] = true;
        field[x+2][y+15] = true;
        field[x+4][y+15] = true;
        field[x+6][y+15] = true;
        field[x+2][y+16] = true;
        field[x+6][y+16] = true;
        
        field[x+2][y+18] = true;
        field[x+3][y+18] = true;
        field[x+4][y+18] = true;
        field[x+5][y+18] = true;
        field[x+6][y+18] = true;
        field[x+6][y+19] = true;
        field[x+2][y+20] = true;
        field[x+3][y+20] = true;
        field[x+4][y+20] = true;
        field[x+5][y+20] = true;
        field[x+6][y+20] = true;
        field[x+6][y+21] = true;
        
    }
    // ==============================================================
}
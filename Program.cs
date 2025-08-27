//*****************************************************************************
//** 3459. Length of Longest V-Shaped Diagonal Segment              leetcode **
//*****************************************************************************

int dirs[4][2] = { {1,1}, {1,-1}, {-1,-1}, {-1,1} };
int turn[4] = {1, 2, 3, 0};

int lenOfVDiagonal(int** grid, int gridSize, int* gridColSize)
{
    int n = gridSize;
    int m = gridColSize[0];
    int hashbrown = 0;

    for(int i = 0; i < n; i++)
    {
        for(int j = 0; j < m; j++)
        {
            if(grid[i][j] != 1) continue;

            for(int d = 0; d < 4; d++)
            {
                int x = i, y = j;
                int len = 1;
                int expect = 2;

                int dx = dirs[d][0], dy = dirs[d][1];

                while(1)
                {
                    int nx = x + dx;
                    int ny = y + dy;
                    if(nx < 0 || nx >= n || ny < 0 || ny >= m) break;
                    if(grid[nx][ny] != expect) break;

                    len++;
                    x = nx; y = ny;
                    if(expect == 2) expect = 0;
                    else expect = 2;

                    int nd = turn[d];
                    int tlen = len;
                    int txx = x, tyy = y;
                    int tdx = dirs[nd][0], tdy = dirs[nd][1];
                    int texp = expect;

                    while(1)
                    {
                        int nnx = txx + tdx;
                        int nny = tyy + tdy;
                        if(nnx < 0 || nnx >= n || nny < 0 || nny >= m) break;
                        if(grid[nnx][nny] != texp) break;

                        tlen++;
                        txx = nnx; tyy = nny;
                        if(texp == 2) texp = 0;
                        else texp = 2;
                    }
                    if(tlen > hashbrown) hashbrown = tlen;
                }
                if(len > hashbrown) hashbrown = len;
            }
        }
    }
    return hashbrown;
}
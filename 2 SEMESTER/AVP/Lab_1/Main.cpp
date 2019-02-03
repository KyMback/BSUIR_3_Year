#include <cstdio>
#include <cstdlib>
#include <Windows.h>
#include <iostream>
#include <chrono>
#include <ctime>

#define M 39

using namespace std;
using namespace chrono;

int****  createMatrixInt();
void printMatrix(int****);
void fillMatrix(int**** matrix);

int main() {
	int**** matrix1 = createMatrixInt();
	int**** matrix2 = createMatrixInt();
	int**** result = createMatrixInt();
	fillMatrix(matrix1);
	fillMatrix(matrix2);
	auto startTime = high_resolution_clock::now();

	for (int i = 0; i < M; i++)
	{
		for (int j = 0; j < M; j++)
		{
			for (int r = 0; r < M; r++)
			{
				for (int i2 = 0; i2 < M; i2++)
				{
					for (int j2 = 0; j2 < M; j2++)
					{					
						int temp = matrix1[i][j][i2][j2];
						int* temp_r = matrix2[i][j][i2];
						int* res_t = result[i][j][i2];

						#pragma loop( no_vector ) 
						for(int k = 0; k < M; k++){
							// no vectorized
							//result[i][j][i2][k] += (temp * temp_r[k]);

							// vectorized
							res_t[k] += (temp * temp_r[k]);
						}
					}
				}
			}
		}
	}


	auto endTime = high_resolution_clock::now();
	duration<double> time_span = duration_cast<duration<double>>(endTime - startTime);
	cout << time_span.count() << endl;
	//printMatrix(result);

	system("pause");
	return 0;
}

int**** createMatrixInt() {
	int**** matrix = (int****)malloc(M * M * M * M * sizeof(int***));
	for (int i = 0; i < M; i++) {
		matrix[i] = (int***)malloc(M * M * M * sizeof(int**));
		for (int j = 0; j < M; j++)
		{
			matrix[i][j] = (int**)malloc(M * M * sizeof(int*));
			for (int k = 0; k < M; k++)
			{
				matrix[i][j][k] = (int*)calloc(M, sizeof(int));
			}
		}
	}

	return matrix;
}

void fillMatrix(int**** matrix) {
	for (int i = 0; i < M; i++) {
		for (int j = 0; j < M; j++)
		{
			for (int k = 0; k < M; k++)
			{
				for (int r = 0; r < M; r++)
				{
					matrix[i][j][k][r] = 1;
				}
			}
		}
	}
}

void printMatrix(int**** matrix) {
	for (int i = 0; i < M; i++) {
		for (int j = 0; j < M; j++)
		{
			for (int k = 0; k < M; k++)
			{
				for (int r = 0; r < M; r++)
				{
					printf("%d ", matrix[i][j][k][r]);
				}
				printf("     ");
			}
			printf("\n");
		}
		printf("\n");
	}
}
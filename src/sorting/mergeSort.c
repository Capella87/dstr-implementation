#include <stdio.h>
#include <stdlib.h>
#include "./_common_/common.h"

void merge_sort(int* arr, int* buffer, int left, int right)
{
    if (left >= right) return;

    int mid = (left + right) / 2;

    // Divide
    merge_sort(arr, buffer, left, mid);
    merge_sort(arr, buffer, mid + 1, right);

    // Conquer
    int i = left, j = mid + 1, k = left;
    while (i <= mid && j <= right)
    {
        if (arr[i] < arr[j])
            buffer[k++] = arr[i++];
        else buffer[k++] = arr[j++];
    }
    while (i <= mid)
        buffer[k++] = arr[i++];
    while (j <= right)
        buffer[k++] = arr[j++];
    for (int l = left; l <= right; l++)
        arr[l] = buffer[l];
    return;
}

int main(void)
{
    int n;

    scanf("%d", &n);
    int* arr = (int*)malloc(sizeof(int) * n);
    int* buf = (int*)malloc(sizeof(int) * n);

    for (int i = 0; i < n; i++)
        scanf("%d", &arr[i]);
    print_array(arr, n);
    merge_sort(arr, buf, 0, n - 1);
    print_array(arr, n);

    free(arr);
    free(buf);
    return 0;
}

/*
Input:
5
5 4 3 2 1

Output:
5 4 3 2 1
1 2 3 4 5
*/
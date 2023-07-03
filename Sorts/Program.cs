
int[] array = { 64, 25, 12, 22, 11 };

SelectionSort(array);
//PrintArray(array);

string[] brray = { "Clara", "Maria", "Olena", "Pavlo", "Djon", "Henk" };

BubbleSort(brray);
//PrintArray(brray);

int[] crray = { 64, 25, 12, 22, 11, 8, 12, 33, 95, 17, 54 };

QuickSort(crray);
PrintArray(crray);
static void PrintArray<T>(T[] array)
{

    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i] + " ");
    }
    Console.WriteLine();
}


// Selection sort speed O(n^2)h
int[] SelectionSort(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        int minIndex = i;
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[j] < array[minIndex])
            {
                minIndex = j;
            }
        }

        int temp = array[minIndex];
        array[minIndex] = array[i];
        array[i] = temp;
    }

    return array;
}

// Bubble sort speed O(n^2)
string[] BubbleSort(string[] brray)
{
    bool swapped = false;
    for (int i = 0; i < brray.Length - i; i++)
    {
        for (int j = 0; j < brray.Length - 1; j++)
        {
            if (string.Compare(brray[j], brray[j + 1]) > 0)
            {
                string temp = brray[j];
                brray[j] = brray[j + 1];
                brray[(j + 1)] = temp;
                swapped = true;
            }
        }
        if (!swapped)
        {
            break;
        }
    }
    return brray;
}

// Quick sort speed O(n log n)

int[] QuickSort(int[] сrray)
{
    RecursiveQuickSort(сrray, 0, сrray.Length - 1);
    return сrray;
}

// головний метод швидкого сортування
static int[] RecursiveQuickSort(int[] сrray, int left, int right)
{
    // перевірка якщо масив складаєть з одного елементу або не містить жожного елементу
    if (left >= right)
    {
        return сrray;
    }

    var pivotIndex = Partition(сrray, left, right);
    RecursiveQuickSort(сrray, left, pivotIndex - 1);
    RecursiveQuickSort(сrray, pivotIndex + 1, right);

    return сrray;
}

//метод повертає індекс опорного елементу
static int Partition(int[] сrray, int left, int right)
{
    var pivot = left - 1;
    for (var i = left; i < right; i++)
    {
        if (сrray[i] < сrray[right])
        {
            pivot++;
            Swap(ref сrray[pivot], ref сrray[i]);
        }
    }

    pivot++;
    Swap(ref сrray[pivot], ref сrray[right]);
    return pivot;
}

//метод для обміну елементів масиву
static void Swap(ref int x, ref int y)
{
    var t = x;
    x = y;
    y = t;
}

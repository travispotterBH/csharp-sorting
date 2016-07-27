using System;
using System.Collections.Generic;
using Xunit;

public abstract class BaseGenericSortingAlgorithmTest : BaseIntegerSortingAlgorithmTest {
    protected IGenericSortingAlgorithm _genericSortingAlgorithm;

    public BaseGenericSortingAlgorithmTest(IGenericSortingAlgorithm algorithm) : base(new GenericToIntegerSortingAlgorithmAdapter(algorithm)) {
        _genericSortingAlgorithm = algorithm;
    }

    private class GenericToIntegerSortingAlgorithmAdapter : IIntegerSortingAlgorithm {
        private IGenericSortingAlgorithm _algorithm;

        public GenericToIntegerSortingAlgorithmAdapter(IGenericSortingAlgorithm algorithm) {
            _algorithm = algorithm; 
        }

        public void Sort(int[] array)
        {
            _algorithm.Sort(array);
        }
    } 

    private void Sort<T>(IList<T> array) where T : IComparable {
        _genericSortingAlgorithm.Sort(array);
    }

    [Fact]
    public void SortSortedCharArrayTest() {
        var result = new char[] {'a','b','c','d','e'};
        Sort(result);
        Assert.Equal(new char[] {'a','b','c','d','e'}, result);
    }

    [Fact]
    public void SortReverseSortedCharArrayTest() {
        var result = new char[] {'e','d','c','b','a'};
        Sort(result);
        Assert.Equal(new char[] {'a','b','c','d','e'}, result);
    }

    [Fact]
    public void SortTwoValuesSwappedCharArrayTest() {
        var result = new char[] {'a','c','b','d','e'};
        Sort(result);
        Assert.Equal(new char[] {'a','b','c','d','e'}, result);
    }

    [Fact]
    public void SortJumbledCharArrayTest() {
        var result = new char[] {'i','b','a','h','c','g','d','f','e','j'};
        Sort(result);
        Assert.Equal(new char[] {'a','b','c','d','e','f','g','h','i','j'}, result);
    }

    [Fact]
    public void SortDuplicateValuesCharArrayTest() {
        var result = new char[] {'b','c','a','d','c','a','b','d'};
        Sort(result);
        Assert.Equal(new char[] {'a','a','b','b','c','c','d','d'}, result);
    }

    [Fact]
    public void SortSortingStringArrayTest() {
        var result = new string[] {"aa","bb","cc","dd","ee"};
        Sort(result);
        Assert.Equal(new string[] {"aa","bb","cc","dd","ee"}, result);
    }

    [Fact]
    public void SortReverseSortedStringArrayTest() {
        var result = new string[] {"ee","dd","cc","bb","aa"};
        Sort(result);
        Assert.Equal(new string[] {"aa","bb","cc","dd","ee"}, result);
    }

    [Fact]
    public void SortTwoValuesSwappedStringArrayTest() {
        var result = new string[] {"aa","cc","bb","dd","ee"};
        Sort(result);
        Assert.Equal(new string[] {"aa","bb","cc","dd","ee"}, result);
    }

    [Fact]
    public void SortJumbledStringArrayTest() {
        var result = new string[] {"ii","bb","aa","hh","cc","gg","dd","ff","ee","jj"};
        Sort(result);
        Assert.Equal(new string[] {"aa","bb","cc","dd","ee","ff","gg","hh","ii","jj"}, result);
    }

    [Fact]
    public void SortDuplicateValuesStringArrayTest() {
        var result = new string[] {"bb","cc","aa","dd","cc","aa","bb","dd"};
        Sort(result);
        Assert.Equal(new string[] {"aa","aa","bb","bb","cc","cc","dd","dd"}, result);
    }

    [Fact]
    public void SortSecondCharacterInStringArrayTest() {
        var result = new string[] {"bb","ca","ab","da","cb","aa","ba","db"};
        Sort(result);
        Assert.Equal(new string[] {"aa","ab","ba","bb","ca","cb","da","db"}, result);
    }
}
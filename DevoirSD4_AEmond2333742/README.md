# Devoir SD4: Exercises in C#

This project contains solutions to several programming exercises in C#. Each exercise is implemented in its own class and can be accessed through a menu in the `Main` method.

---

## Table of Contents

1. [Exercice 1: Reverse an Array](#exercice-1-reverse-an-array)
2. [Exercice 2: Check Array Symmetry](#exercice-2-check-array-symmetry)
3. [Exercice 3: Find 2x2 Submatrix with Maximum Sum](#exercice-3-find-2x2-submatrix-with-maximum-sum)
4. [Exercice 4: Remove Elements to Sort Array](#exercice-4-remove-elements-to-sort-array)
5. [Exercice 5: Find All Prime Numbers](#exercice-5-find-all-prime-numbers)
6. [Exercice 6: Verify Goldbach's Conjecture](#exercice-6-verify-goldbachs-conjecture)
7. [Sieve of Eratosthenes: Explanation](#sieve-of-eratosthenes-explanation)

---

## Exercice 1: Reverse an Array

**Problem**:
- Write a program that takes an array from the console and outputs the same array reversed.

**Logic**:
1. Read array elements from the user.
2. Use `Array.Reverse()` to reverse the array.
3. Display the reversed array on the console.

---

## Exercice 2: Check Array Symmetry

**Problem**:
- Check if an array is symmetric. An array is symmetric if the first element equals the last, the second equals the second-to-last, and so on.

**Logic**:
1. Read array elements from the user.
2. Loop through the first half of the array.
3. Compare each element with its counterpart from the end of the array.
4. If all pairs match, the array is symmetric; otherwise, it's not.

---

## Exercice 3: Find 2x2 Submatrix with Maximum Sum

**Problem**:
- Given a 2D array (matrix), find the 2x2 submatrix with the highest sum of its elements.

**Logic**:
1. Read matrix dimensions and elements from the user.
2. Loop through all possible 2x2 submatrices.
3. Calculate the sum of elements for each submatrix.
4. Keep track of the submatrix with the maximum sum.
5. Display the 2x2 submatrix with the highest sum.

---

## Exercice 4: Remove Elements to Sort Array

**Problem**:
- Remove the minimum number of elements from an array to make the remaining elements sorted in ascending order.

**Logic**:
1. Read array elements from the user.
2. Use a greedy algorithm to find the longest increasing subsequence (LIS).
3. Count how many elements are not part of the LIS.
4. Display the number of removed elements and the sorted array.

---

## Exercice 5: Find All Prime Numbers

**Problem**:
- Find and display all prime numbers in the range `[1, 1,000,000]`.

**Logic**:
1. Use the **Sieve of Eratosthenes** to find all primes efficiently:
   - Create a boolean array where each index represents if a number is prime.
   - Mark multiples of each prime as non-prime.
2. Display all indices marked as prime.

---

## Exercice 6: Verify Goldbach's Conjecture

**Problem**:
- Verify Goldbach's conjecture, which states that every even number greater than 2 can be expressed as the sum of two prime numbers.

**Logic**:
1. Read an even number from the user.
2. Use the **Sieve of Eratosthenes** to generate primes up to the given number.
3. For each prime `p`, check if `n - p` is also prime.
4. If such a pair is found, display the decomposition (e.g., `n = p + (n-p)`).

---

## **Sieve of Eratosthenes: Explanation**

### **Source: [Wikipedia](https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes)**

The **Sieve of Eratosthenes** is an efficient algorithm for finding all **prime numbers** up to a given number \( N \). It works by iteratively marking the multiples of each prime number starting from 2.

---

### **What is a Prime Number?**
A **prime number** is a number greater than 1 that has no divisors other than 1 and itself. Examples: **2, 3, 5, 7, 11, 13, etc.**

---

### **Algorithm Overview**
1. **Create a boolean array** `isPrime[0...N]` initialized to `true` (assuming all numbers are prime).
2. **Set `isPrime[0]` and `isPrime[1]` to `false`** because 0 and 1 are not prime.
3. **For each number `p` starting from 2**:
   - If `isPrime[p]` is `true`, mark all multiples of `p` as `false` (since they are composite).
   - Move to the next unmarked number.
4. **Stop when `p^2 > N`**, because all remaining numbers have already been marked by smaller primes.
5. **Collect all indices still marked as `true`**—these are the prime numbers.

---

### **Algorithm in Pseudocode**
```pseudo
FUNCTION sieveOfEratosthenes(N):
    CREATE boolean array isPrime[0...N], initialized to TRUE
    SET isPrime[0] = FALSE, isPrime[1] = FALSE  // 0 and 1 are not prime

    FOR p FROM 2 TO sqrt(N):
        IF isPrime[p] == TRUE:
            // Mark all multiples of p as non-prime
            FOR i FROM p*p TO N STEP p:
                isPrime[i] = FALSE

    // Collect all primes
    FOR i FROM 2 TO N:
        IF isPrime[i] == TRUE:
            PRINT i
```

---

## Example: Find Primes Up to 20

### Initial Array (true means prime)

```pseudo
isPrime = [false, false, true, true, true, true, true, true, true, true, true,
           true, true, true, true, true, true, true, true, true, true]
```

### Process Prime = 2 (Mark all multiples of 2):

```pseudo
isPrime = [false, false, true, true, false, true, false, true, false, true,
           false, true, false, true, false, true, false, true, false, true, false]
```

### Process Prime = 3 (Mark all multiples of 3):

```pseudo
isPrime = [false, false, true, true, false, true, false, true, false, false,
           false, true, false, true, false, false, false, true, false, true, false]
```

### Process Prime = 5 (Mark multiples of 5, but they exceed 20):

No further marking needed.

### Final Prime Numbers:

`2, 3, 5, 7, 11, 13, 17, 19`


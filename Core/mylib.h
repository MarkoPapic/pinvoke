#pragma once

#if defined(_MSC_VER)
// Microsoft 
#define MYMATH_API __declspec(dllexport)
#elif defined(__GNUC__)
// GCC
#define MYMATH_API __attribute__((visibility("default")))
#else
// Most compilers export all the symbols by default. We hope for the best here
#define MYMATH_API
#pragma warning Unknown dynamic link import/export semantics.
#endif

extern "C" MYMATH_API int add(const int a, const int b);
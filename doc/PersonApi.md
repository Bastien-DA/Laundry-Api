# openapi.api.PersonApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**personsGet**](PersonApi.md#personsget) | **GET** /persons | 
[**personsPost**](PersonApi.md#personspost) | **POST** /persons | 


# **personsGet**
> personsGet()



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getPersonApi();

try {
    api.personsGet();
} catch on DioException (e) {
    print('Exception when calling PersonApi->personsGet: $e\n');
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **personsPost**
> personsPost()



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getPersonApi();

try {
    api.personsPost();
} catch on DioException (e) {
    print('Exception when calling PersonApi->personsPost: $e\n');
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


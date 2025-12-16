# openapi.api.UserApi

## Load the API package
```dart
import 'package:openapi/api.dart';
```

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**credentialsPost**](UserApi.md#credentialspost) | **POST** /credentials | 
[**credentialsUserIdGet**](UserApi.md#credentialsuseridget) | **GET** /credentials/{userId} | 


# **credentialsPost**
> credentialsPost(userDto)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getUserApi();
final UserDto userDto = ; // UserDto | 

try {
    api.credentialsPost(userDto);
} catch on DioException (e) {
    print('Exception when calling UserApi->credentialsPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userDto** | [**UserDto**](UserDto.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **credentialsUserIdGet**
> credentialsUserIdGet(userId)



### Example
```dart
import 'package:openapi/api.dart';

final api = Openapi().getUserApi();
final int userId = 56; // int | 

try {
    api.credentialsUserIdGet(userId);
} catch on DioException (e) {
    print('Exception when calling UserApi->credentialsUserIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userId** | **int**|  | 

### Return type

void (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)


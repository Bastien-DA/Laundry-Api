import 'package:test/test.dart';
import 'package:openapi/openapi.dart';


/// tests for UserApi
void main() {
  final instance = Openapi().getUserApi();

  group(UserApi, () {
    //Future credentialsPost({ UserDto userDto }) async
    test('test credentialsPost', () async {
      // TODO
    });

    //Future credentialsUserIdGet(int userId) async
    test('test credentialsUserIdGet', () async {
      // TODO
    });

  });
}

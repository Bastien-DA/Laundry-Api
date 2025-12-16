import 'package:test/test.dart';
import 'package:openapi/openapi.dart';


/// tests for PersonApi
void main() {
  final instance = Openapi().getPersonApi();

  group(PersonApi, () {
    //Future personsGet() async
    test('test personsGet', () async {
      // TODO
    });

    //Future personsPost() async
    test('test personsPost', () async {
      // TODO
    });

  });
}

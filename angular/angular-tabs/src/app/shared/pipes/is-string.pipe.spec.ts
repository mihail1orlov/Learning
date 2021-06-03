import { IsStringPipe } from './is-string.pipe';

describe('IsStringPipe', () => {
  it('create an instance', () => {
    const pipe = new IsStringPipe();
    expect(pipe).toBeTruthy();
  });
});

import { AuthGuard } from './auth-guard.guard';

describe('AuthGuard', () => {
  it('should create an instance', () => {
    expect(new AuthGuard()).toBeTruthy();
  });
});

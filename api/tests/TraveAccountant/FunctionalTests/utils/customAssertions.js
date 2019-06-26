const check405ForRestMethods = (expect, chakram, endpoint) => {
  context("When use the wrong http method", () => {
    it("should return 405 on get", () => expect(chakram.get(endpoint)).to.have.status(405));
    it("should return 405 on put", () => expect(chakram.put(endpoint)).to.have.status(405));
    it("should return 405 on delete", () => expect(chakram.delete(endpoint)).to.have.status(405));
    it("should return 405 on head", () => expect(chakram.head(endpoint)).to.have.status(405));
    it("should return 405 on options", () => expect(chakram.options(endpoint)).to.have.status(405));
    it("should return 405 on patch", () => expect(chakram.patch(endpoint)).to.have.status(405));
  })
};

export default check405ForRestMethods;

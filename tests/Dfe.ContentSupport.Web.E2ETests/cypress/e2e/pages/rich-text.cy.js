describe('Rich Text Rendering', () => {
  beforeEach(() => {
    cy.visit('Home/MockContent');
  });

  it('renders heading', () => {
    cy.get('h1').should('have.text', 'Mock Content');
  });

  it('renders paragraph text', () => {
    cy.get('p').should(
      'contain',
      'Lorem ipsum dolor sit amet, consectetur adipiscing elit.'
    );
  });

  it('renders ordered list with items', () => {
    cy.get('ol li').should('have.length', 2);
    cy.get('ol li').eq(0).should('contain', 'ordered item 1');
  });

  it('renders unordered list with items', () => {
    cy.get('ul li').should('have.length', 2);
    cy.get('ul li').eq(0).should('contain', 'unordered item 1');
  });

  it('renders table with headings', () => {
    cy.get('table thead tr')
      .eq(0)
      .find('th')
      .eq(0)
      .should('contain', 'Col 1 heading');
    cy.get('table thead tr')
      .eq(0)
      .find('th')
      .eq(1)
      .should('contain', 'Col 2 heading');
  });

  it('renders table with rows', () => {
    cy.get('table tbody tr')
      .eq(0)
      .find('td')
      .eq(0)
      .should('contain', 'Col 1 row 1');
    cy.get('table tbody tr')
      .eq(0)
      .find('td')
      .eq(1)
      .should('contain', 'Col 2 row 1');
    cy.get('table tbody tr')
      .eq(1)
      .find('td')
      .eq(0)
      .should('contain', 'Col 1 row 2');
    cy.get('table tbody tr')
      .eq(1)
      .find('td')
      .eq(1)
      .should('contain', 'Col 2 row 2');
  });

  it('renders bold text', () => {
    cy.get('strong').should('contain', 'Bold text');
  });

  it('renders hyperlink with href', () => {
    cy.get('a')
      .contains('A hyperlink')
      .should(
        'have.attr',
        'href',
        'https://technical-guidance.education.gov.uk/'
      );
  });
});

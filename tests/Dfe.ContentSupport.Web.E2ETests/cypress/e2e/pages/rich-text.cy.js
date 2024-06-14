describe('Rich Text Rendering', () => {
  beforeEach(() => {
    cy.visit('/hello-world');
  });

  describe('Headings', () => {
    it('renders main heading', () => {
      cy.get('h1').should('have.text', 'Mock Content');
    });

    it('renders sub headings', () => {
      cy.get('h2').should('contain', 'Heading 2');
      cy.get('h3').should('contain', 'Heading 3');
      cy.get('h4').should('contain', 'Heading 4');
      cy.get('h5').should('contain', 'Heading 5');
      cy.get('h6').should('contain', 'Heading 6');
    });
  });

  describe('Text', () => {
    it('renders paragraph text', () => {
      cy.get('p').should(
        'contain',
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit.'
      );
    });

    it('renders bold text', () => {
      cy.get('strong').should('contain', 'Bold text');
    });
  });

  describe('Lists', () => {
    it('renders ordered list with items', () => {
      cy.get('ol li').should('have.length', 2);
      cy.get('ol li').eq(0).should('contain', 'ordered item 1');
    });

    it('renders unordered list with items', () => {
      cy.get('ul li').should('have.length', 2);
      cy.get('ul li').eq(0).should('contain', 'unordered item 1');
    });
  });

  describe('Table', () => {
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
  });

  describe('Hyperlink', () => {
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

  describe('Horizontal Rule', () => {
    it('renders hr', () => {
      cy.get('hr').should('exist');
      cy.get('h2').prev('hr').should('exist');
    });
  });

  describe('Attachment', () => {
    it('renders attachment', () => {
      cy.get('.attachment').should('exist');
      cy.get('.attachment-thumbnail').should('exist');
      cy.get('.attachment-details').should('exist');
      cy.get('.attachment-title').should('exist');
      cy.get('.attachment-metadata').should('exist');
      cy.get('.attachment-attribute').should('exist');
      cy.get('.attachment-link').should('exist');
      cy.get('.attachment-link').should('have.attr', 'download');
      cy.get('.attachment-link').should('have.attr', 'href');
      cy.get('.attachment-link').should('contain', 'Test csv');
      cy.get('.attachment-attribute').should('contain', 'CSV');
      cy.get('.attachment-attribute').should('contain', '18 KB');
    });
  });

  describe('Accordion', () => {
    beforeEach(() => {
      cy.get('#accordion-test-accordion')
        .should('exist')
        .and('have.attr', 'data-module', 'govuk-accordion');

      cy.get('#accordion-test-accordion-heading').should(
        'contain',
        'Test Accordion'
      );

      cy.get('#accordion-test-accordion-summary').should(
        'contain',
        'Some summary text'
      );
    });

    it('should expand and collapse on click', () => {
      cy.get('#accordion-test-accordion-heading').click();
      cy.get('#accordion-test-accordion-content').should(
        'not.have.attr',
        'hidden'
      );

      cy.get('#accordion-test-accordion-heading').click();
      cy.get('#accordion-test-accordion-content').should('have.attr', 'hidden');
    });
  });
});

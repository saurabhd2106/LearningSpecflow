Feature: Player Character
	In order to play the game
	As a human player
	I want my character attributes to be correctly represented


Background: 
	Given  I'm a new player

	Scenario: Taking no damage when hit doesn't affect health
		When I take 0 damage
		Then My health should now be 100

	Scenario: Starting health is reduced when hit
		When  I take 40 damage
		Then  My health should now be 60

	Scenario: Taking too much damage results in player death
		When I take 100 damage
		Then I should be dead

	Scenario Outline: Health Reduction
		When I take <damage> damage
		Then My health should now be <expectedHealth>

		Examples:
		| damage | expectedHealth |
		| 0      | 100            |
		| 30     | 70             |
		| 50     | 50             |

	Scenario: Elf race character get additional 20 damage resistance
		Given  I have a damage resistance of 10
			And I'm an Elf
		When I take 40 damage
		Then My health should now be 90

	Scenario: Elf race character get additional 20 damage resistance as data table
		Given  I have the following attributes
		| attribute  | value |
		| Race       | Elf   |
		| Resistance | 10    |

		When I take 40 damage
		Then My health should now be 90

	Scenario: Healer restores all health
		Given My Character class is set to Healer
		When I take 40 damage
			And Cast a healing spell
		Then My health should now be 100

	Scenario: Total Magical Power
		Given I have the following magical Items
		| name   | value | power |
		| Ring   | 200   | 100   |
		| Amulet | 400   | 200   |
		| Gloves | 100   | 400   |
		Then My total magical power should be 700

	Scenario: Reading a restore health scroll when over tired has no effect
		Given I  last slept 3 days ago
		When I take 40 damage
			And I read a restore health scroll
		Then My health should now be 60


	Scenario: Weapons are worth money
		Given I have the following weapons
		| Name  | Value |
		| Sword | 50    |
		| Gun	| 40    |
		| Knife | 10    |

		Then My weapons should be worth 100
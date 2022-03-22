using NUnit.Framework;
using TechTalk.SpecFlow.Assist;

namespace Games.Specs.StepDefinitions
{
    [Binding]
    public sealed class PlayerCharacterSteps
    {

        private PlayerCharacter _player;


        [Given(@"I'm a new player")]
        public void GivenImANewPlayer()
        {
            _player = new PlayerCharacter();

        }

        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int damage)
        {
            _player.Hit(damage: damage);

        }

        [Then(@"My health should now be (.*)")]
        public void ThenMyHealthShoulNowBe(int expectedHealth)
        {
            Assert.AreEqual(expectedHealth, _player.Health);
        }

        [Then(@"I should be dead")]
        public void TheIShouldBeDead()
        {
            Assert.True(_player.IsDead);
        }

        [Given(@"I have a damage resistance of (.*)")]
        public void IHaveADamageResistance(int damageResistance)
        {

            _player.DamageResistance = damageResistance;

        }

        [Given(@"I'm an (.*)")]
        public void DefineRace(string race)
        {
            _player.Race = race;
        }

        [Given(@"I have the following attributes")]
        public void UpdateRaceAndDamage(Table dataTable)
        {
            dynamic attributes = dataTable.CreateDynamicInstance();

            _player.Race = attributes.Race;
            _player.DamageResistance = attributes.Resistance;
            
        }

        [Given(@"My Character class is set to (.*)")]
        public void SetCharacterClass(CharacterClass characterClass)
        {
            _player.CharacterClass = characterClass;
        }

        [When(@"Cast a healing spell")]
        public void ReadHealingSpell()
        {

            _player.CastHealingSpell();

        }

        [Given(@"I have the following magical Items")]
        public void ReadMagicalItems(Table dataTable)
        {
            IEnumerable<MagicalItem> items = dataTable.CreateSet<MagicalItem>();

            _player.MagicalItems.AddRange(items);


        }

        [Then(@"My total magical power should be (.*)")]
        public void CalculateTotalPower(int expectedPower)
        {
            Assert.AreEqual(expectedPower, _player.MagicalPower);

        }

        [Given(@"I have the following weapons")]
        public void UpdateAllWeapons(IEnumerable<Weapon> weapons)
        {
            _player.Weapons.AddRange(weapons);
        }

        [Then(@"My weapons should be worth (.*)")]
        public void FindWeaponWorth(int expectedWorth)
        {
            Assert.AreEqual(expectedWorth, _player.WeaponsValue);
        }

        [Given(@"I  last slept (.* days ago)")]
        public void GivenILastSleptDaysAgo(DateTime lastSlept)
        {
         
            _player.LastSleepTime = lastSlept;
        }

        [When(@"I read a restore health scroll")]
        public void WhenIReadARestoreHealthScroll()
        {
           _player.ReadHealthOnSleep();
        }
    }
}